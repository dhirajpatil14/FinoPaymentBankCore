using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using HotRod.Cache.Connector;
using LoginService.Application.Contracts.Repositories;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Login.Infrastructure.Repositories
{
    class UserRepositories : IUserRepositories
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly ICacheConnector _cacheConnector;
        private readonly SqlConnectionStrings _sqlConnectionStrings;


        public UserRepositories(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnectionStrings, ICacheConnector cacheConnector)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _cacheConnector = cacheConnector;
            _sqlConnectionStrings = sqlConnectionStrings.Value;
        }

        public async Task<Reasons> GetReasonsAsync(string reasonsCode)
        {
            var config = new DataDbConfigSettings<Reasons>
            {
                TableEnums = PBMaster.ReasonMaster,
                Request = new Reasons { RevokeReason = reasonsCode },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<Reasons, Reasons>(configSettings: config);
        }

        public async Task<IEnumerable<UserRestriction>> GetUserRestricationAsync(FisUserPasswordValidateRequest fisUserPasswordValidateRequest, int latlong)
        {
            var parameter = new
            {
                Ip = fisUserPasswordValidateRequest?.SystemInfo?.Ip?.ToString(),
                CellId = fisUserPasswordValidateRequest?.SystemInfo?.CellId.ToString(),
                MacDeviceId = fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId.ToString(),
                Mcc = fisUserPasswordValidateRequest?.SystemInfo?.Mcc.ToString(),
                Lattitude = fisUserPasswordValidateRequest?.GeoLocation?.Lattitude.ToString(),
                Longitude = fisUserPasswordValidateRequest?.GeoLocation?.Longitude.ToString()
            };

            var geoCoordinate = new GeoCoordinate.NetStandard2.GeoCoordinate(fisUserPasswordValidateRequest.GeoLocation.Longitude, fisUserPasswordValidateRequest.GeoLocation.Longitude);
            if (geoCoordinate.IsUnknown)
            {

                ////var lat = Convert.ToDouble(fisUserPasswordValidateRequest?.GeoLocation?.Lattitude.ToString().Substring(0, latlong));
                ////var longt = Convert.ToDouble(fisUserPasswordValidateRequest?.GeoLocation?.Longitude.ToString().Substring(0, latlong));
                //fisUserPasswordValidateRequest.GeoLocation.Lattitude = lat;
                //fisUserPasswordValidateRequest.GeoLocation.Longitude = longt;
                fisUserPasswordValidateRequest.GeoLocation.Lattitude = 0;
                fisUserPasswordValidateRequest.GeoLocation.Longitude = 0;
            }


            StringBuilder query = new();
            query.Append("SELECT * FROM tblUserRestriction WITH (NOLOCK) WHERE Status= 1 AND ( ");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" && fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null ? $"IPAddress = @Ip " : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" && fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null && !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) ? $" OR CellID=@CellId" : !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) ? $" CellID=@CellId" : "");
            query.Append(!string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId) && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId)) ? $" OR DeviceId=@MacDeviceId" : !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId) ? $" DeviceId=@MacDeviceId" : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "" && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId)) ? $" OR MCC=@Mcc" : fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "" ? $" MCC=@Mcc" : "");
            query.Append(fisUserPasswordValidateRequest?.GeoLocation?.Lattitude is not 0 && fisUserPasswordValidateRequest?.GeoLocation?.Longitude is not 0 && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId) || fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "") ? $" OR ( Latitude=@Lattitude AND Longitude=@Longitude )" : fisUserPasswordValidateRequest?.GeoLocation?.Lattitude is not 0 && fisUserPasswordValidateRequest?.GeoLocation?.Longitude is not 0 ? $" Latitude=@Lattitude AND Longitude=@Longitude " : "");
            query.Append(" ) ");
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<object, UserRestriction>(configSettings: config);
        }

        public async Task<int> AddUserGeoAsync(GeoUserLocation geoUserLocation)
        {
            var config = new DataDbConfigSettings<GeoUserLocation>
            {
                TableEnums = PBTranscation.GeoUserLocation,
                Request = geoUserLocation,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };
            return await _dataDbConfigurationService.AddDataAsync<GeoUserLocation>(configSettings: config);
        }

        public async Task<UserType> GetUserTypeAsync(string userType)
        {
            var config = new DataDbConfigSettings<UserType>
            {
                TableEnums = PBMaster.USERTYPE,
                Request = new UserType { UserTypeName = userType },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.GetDataAsync<UserType, UserType>(configSettings: config);
        }

        public async Task<int> CheckEagreementAsync(string merchantName, string merchantId, int expiryday)
        {
            var parameter = new
            {
                MerchantName = merchantName,
                MerchantID = merchantId,
                AgreementExpiryday = expiryday
            };

            var query = $"Select * from (SELECT Top 1 MerchantName,DistributorName,CreatedDate,CASAaddendum FROM tblEAgreement with (NOLOCK) where MerchantID=@MerchantID  order by AutoID desc) EAgreement where GETDATE() > DATEADD(day, @AgreementExpiryday, CreatedDate) and MerchantName != @MerchantName";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };
            var data = await _dataDbConfigurationService.GetDataAsync<object, EAgreement>(configSettings: config);

            return data is not null ? 1 : 0;
        }

        public async Task<int> CheckCASAaddendumAsync(string merchantId)
        {
            var parameter = new
            {
                MerchantID = merchantId
            };

            var query = $"SELECT Top 1 MerchantName,DistributorName,CreatedDate,CASAaddendum FROM tblEAgreement with (NOLOCK) where MerchantID=@MerchantID  order by AutoID desc";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };
            var data = await _dataDbConfigurationService.GetDataAsync<object, EAgreement>(configSettings: config);
            return data?.CASAaddendum ?? 0;
        }

        public async Task<int> CheckFilebaseCasaAsync(string merchantId)
        {
            var parameter = new
            {
                MerchantID = merchantId
            };

            var query = $"DECLARE @CASAEfromfile INT;DECLARE @CASAEAgreemen INT; DECLARE @OUTPUT INT; set @OUTPUT =0;" +
                $"Select @CASAEfromfile = COUNT(*) FROM (select TOP 1 MerchantID from tblCASAEAgreementfromfile with(nolock) where MerchantID=@MerchantID) As fromFile " +
                        $"if @CASAEfromfile > 0 " +
                        $"BEGIN " +
                        $"Select @CASAEAgreemen = COUNT(*) FROM (SELECT Top 1 MerchantID FROM tblCASAEAgreement with(nolock) where MerchantID=@MerchantID) As aggrement " +
                        $"if @CASAEAgreemen > 0 " +
                        $"BEGIN " +
                        $"set @OUTPUT = 0; " +
                        $"END " +
                        $"ELSE " +
                        $"BEGIN " +
                        $"set @OUTPUT = 1; " +
                        $"END " +
                        $"END " +
                        $"ELSE " +
                        $"BEGIN " +
                        $"set @OUTPUT = 0; " +
                        $"END " +
                        $"SELECT @OUTPUT As FilebaseCasa";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };

            return await _dataDbConfigurationService.GetDataAsync<object, int>(configSettings: config);
        }

        public async Task<int> CheckSurveyAsync(string channelId, string userClass, string appId, string tellerId)
        {
            var parameterSurveMapper = new
            {
                ChannelId = channelId,
                UserClass = userClass,
                AppId = appId,
                SurveyId = 0,
                TellerID = tellerId
            };
            var querySurveMapper = $"select top 1 ms.SurveyId from mstSurvey ms with(nolock) inner join mstSurveyMapper msm with(nolock) on ms.SurveyId=msm.SurveyId where msm.ChannelId=@ChannelId and msm.UserClass=@UserClass and msm.AppId=@AppId and convert(int,convert(varchar(10),GETDATE(),112)) between convert(int,convert(varchar(10),Startdate,112)) and convert(int,convert(varchar(10),Enddate,112))";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = querySurveMapper.ToString(),
                Request = parameterSurveMapper,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            var data = await _dataDbConfigurationService.GetDataAsync<object, int?>(configSettings: config);

            if (data is not null && data > 0)
            {
                var querySurveyTranscation = $"select top 1 SurveyId from PBTransactionInfo.dbo.tblSurveyTransaction tst with(nolocK) where  tst.surveyid=@SurveyId and tst.UserId=@TellerID and tst.UserClass=@UserClass and tst.ChannelId=@ChannelId and tst.AppID=@AppId";
                config = new DataDbConfigSettings<object>
                {
                    PlainQuery = querySurveyTranscation.ToString(),
                    Request = parameterSurveMapper,
                    DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
                };

                data = await _dataDbConfigurationService.GetDataAsync<object, int?>(configSettings: config);

                return data is not null && data > 0 ? 0 : 1;
            }
            return 0;
        }

        public async Task<int> CheckCategoryCodeAsync(string merchantId)
        {
            var parameter = new
            {
                MerchantID = merchantId
            };

            var query = $"SELECT top 1 category_code from tblMerchantCustSupportInfo  with(nolocK) where   MerchantID =@MerchantID";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };
            var data = await _dataDbConfigurationService.GetDataAsync<object, int?>(configSettings: config);
            return data is 10 ? 10 : 0;
        }

        public async Task<OfferConsent> CheckOfferConsentAsync(string merchantId)
        {
            var parameter = new
            {
                MerchantID = merchantId
            };

            var query = $" SELECT CASE WHEN ConYN >0 THEN 'TRUE' ELSE 'FALSE' END AS ConsentYN ,CASE WHEN OfferYN >0 THEN 'TRUE' ELSE 'FALSE' END AS OfferYN FROM " +
                                             " ( SELECT TOP 1 MerchantID,ID ConYN,'' OfferYN FROM TblMerchantLoanConsentDetails WITH(NOLOCK)  " +
                                             " WHERE Cast(Getdate() as date)<= DATEADD(day,ExpiryDays,cast(Importdatetime as date)) AND MerchantActionStatus=0 AND MerchantID = @MerchantID" +
                                             " Union all  " +
                                             " SELECT TOP 1 MerchantID,'' ConYN,ID OfferYN FROM TblMerchantPreApproveLoanDetails WITH(NOLOCK)  " +
                                             " WHERE Cast(Getdate() as date)<= ExpiryDate AND MerchantActionStatus=0 AND MerchantID = @MerchantID )as A";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };
            var data = await _dataDbConfigurationService.GetDataAsync<object, OfferConsent>(configSettings: config);

            return data ?? new OfferConsent();
        }

        public async Task<string> CheckLoyaltyRewardsAsync(string merchantId)
        {
            var parameter = new
            {
                MerchantID = merchantId
            };

            var query = "SELECT RewardPoints FROM tblLoyaltyRewards  with(NOLOCK) where MerchantId = @MerchantID";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBtransactionInfoConnection
            };
            //check condition if data is present assign value other wise set empty
            var data = await _dataDbConfigurationService.GetDataAsync<object, string>(configSettings: config);
            return data ?? string.Empty;
        }

        public async Task<string> GetLastDownloadAsync()
        {

            var query = " declare  @iLastDownload varchar(100)=''; " +
                " declare @pLastDownload varchar(100)='' " +
                " declare @pModeID nvarchar(10)='' " +
                " CREATE Table #LastDownload(LastDownload Datetime) " +
                " INSERT INTO #LastDownload(LastDownload) " +
                " select top 1 CreatedDate from MstBiller (nolock) order by 1 desc " +
                " INSERT INTO #LastDownload(LastDownload)  select top 1 CreatedDate from  MstBillerDetail (nolock) order by 1 desc " +
                " select @iLastDownload = cast(max(LastDownload) as date) from #LastDownload " +
                " select @iLastDownload UpdatedDate " +
                " DROP TABLE #LastDownload IF OBJECT_ID('#LastDownload') IS NOT NULL DROP TABLE #LastDownload ";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = { },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            //check condition if data is present assign value other wise set empty
            return await _dataDbConfigurationService.GetDataAsync<object, string>(configSettings: config);

        }

        public async Task<string> GetGLZeroizeDateTimeAsync(string userId)
        {
            var parameter = new
            {
                UserId = userId
            };
            var query = "SELECT Convert(varchar(50),ZeroizationDateTime,103) as ZeroizationDateTime FROM tblZeroizeCashGL WITH (NOLOCK) WHERE UserId=@UserId ORDER BY Id DESC";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.GetDataAsync<object, string>(configSettings: config);
        }

        public async Task<IEnumerable<string>> GetLendingVersionAsync()
        {
            var query = "SELECT type FROM mstProductType  with (NOLOCK) where LendingFlag=1 order by 1";
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = { },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            var data = await _dataDbConfigurationService.GetDatasAsync<object, string>(config);

            return data;

        }

        public async Task<string> GetDbVersionAsync(DbVersion dbVersion)
        {
            var res = await GetLendingVersionAsync();

            var dataLeading = res.Aggregate(string.Empty, (current, next) => string.Format(" select '" + "MobileTabCntrl{1}' union all{0}", current, next));


            string query = " create table #temp ( " +
                           " MasterCacheKey nvarchar(100) ) " +
                           " insert into #temp  " +
                           " Select '" + dbVersion.MasterVersion + "' union all " +
              " Select '" + dbVersion.Profile + "' union all " +
              " select '" + dbVersion.Menu + "' union all " +
              " select '" + dbVersion.ProductTrans + "' union all " +
              " select '" + dbVersion.Sequence + "' union all " +
              " select '" + dbVersion.MobileTabControl + "' union all " +
              " select '" + dbVersion.Iin + "' union all " +
              " select '" + dbVersion.PrintFormat1 + "' union all " + dataLeading +
              " select '" + dbVersion.CrossSelling + "'" +
              " select MasterCacheKey, case when MasterCacheKey='MastersVersion' then Value else convert(nvarchar,[Version]) end Version into #temp1 " +
              " from pbmaster..MasterCache with (nolock) where masterCacheKey in (select MasterCacheKey from #temp) " +

              " select masterCacheKey into #temp2 from #temp t1 " +
              " where t1.MasterCacheKey not in (select MasterCacheKey from #temp1) " +

              " select masterCacheKey,convert(nvarchar(max),Version) Version from #temp1 " +
              " union all " +
              " select masterCacheKey,'0000' from #temp2 " +

              " drop table #temp drop table #temp1 drop table #temp2 ";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = { },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            var data = await _dataDbConfigurationService.GetDatasAsync<object, MasterCaches>(configSettings: config);
            return data is not null ? string.Join("", data.Where(xx => xx.MasterCacheKey is not "MastersVersion").Select(c => $"{c.MasterCacheKey}#{c.Version}~")) : null;
        }

        public async Task<string> GetVersionFromCacheAsync(string cacheName, bool isFetchMasterVersion)
        {
            var versions = await _cacheConnector.GetCache(cacheName, isFetchMasterVersion);
            return versions;
        }

        public async Task<string> GetProductTypesAsync(string cacheName)
        {
            var datas = await GetLendingVersionAsync();
            var versions = string.Empty;

            foreach (string type in datas)
            {
                var leadingCache = await GetCacheAsync($"{cacheName}{type}");
                if (leadingCache is not null)
                {
                    var versionId = await GetCacheVersionAsync($"{cacheName}{type}");
                    versions = $"{versions}{cacheName}{versionId}{type}#{versionId}~";
                }
                else
                {
                    versions = $"{versions}{cacheName}{type}#0000~";
                }
            }

            return versions;
        }

        public async Task<FosAppVersion> GetFosVersionAsync(string authenticator, string cacheName)
        {
            var fosdata = await GetCacheAsync(cacheName);
            return fosdata is null ? await GetFosVersionCacheAsync(authenticator, cacheName) : fosdata.ToJsonDeSerialize<FosAppVersion>();
        }

        public async Task<string> GetAuaExpiryDataAsync(int status, int id)
        {
            var parameter = new
            {
                Status = status,
                ID = id
            };

            var query = "SELECT AUA_ExpiryDate FROM MSTAUA with (NOLOCK) where Status = @Status and ID = @ID";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBConfigurationConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<object, string>(configSettings: config);
        }

        public async Task<MobileVersion> GetMobileVersionDataAsync(string cacheName)
        {
            var version = await GetCacheAsync(cacheName);
            var firstDefault = version?.ToJsonDeSerialize<IEnumerable<MobileVersion>>();
            var data = version is null ? await _cacheConnector.GetMobileVersionAsync(cacheName) : firstDefault.FirstOrDefault();
            return data;
        }

        public async Task<string> GetMobileVersionCommanAsync(string cacheName)
        {
            var versions = await _cacheConnector.GetCache(cacheName, true);
            var vId = versions is not null ? await GetCacheVersionAsync(cacheName) : null;
            return versions is not null ? $"{cacheName}#{vId}~" : $"{cacheName}#0000~";
        }

        internal async Task<FosAppVersion> GetFosVersionCacheAsync(string authenticator, string cacheName)
        {
            return await _cacheConnector.GetFOSApplicationVersion(authenticator, cacheName);
        }

        internal async Task<string> GetCacheAsync(string cacheName)
        {
            return await _cacheConnector.GetCache(cacheName, true);
        }

        internal async Task<string> GetCacheVersionAsync(string cacheName)
        {
            return await _cacheConnector.GetCacheVersion(cacheName);
        }

    }
}
