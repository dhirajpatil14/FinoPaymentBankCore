using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Master.Cache.Service.MasterCache.DTo;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache.Repositories
{
    public class MasterCacheRepositories : IMasterCacheRepositories
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;

        public MasterCacheRepositories(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnectionStrings)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnectionStrings.Value;
        }

        public async Task<IEnumerable<MasterStatus>> GetMasterVersionAsync(MasterStatus masterStatus)
        {

            var config = new DataDbConfigSettings<MasterStatus>
            {
                TableEnums = PBMaster.MasterStatus,
                Request = masterStatus,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<MasterStatus, MasterStatus>(configSettings: config);
        }

        public async Task<dynamic> ExecuteQueryAsync(string query)
        {
            var config = new DataDbConfigSettings<dynamic>
            {
                PlainQuery = query,
                TableEnums = PBMaster.MasterStatus,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<dynamic, dynamic>(configSettings: config);
        }

        public async Task<int> UpdateMasterStatusAsync(MasterStatus masterStatus)
        {
            var query = "update tblmastersStatus set [Version]=@Version ,UpdatedDate = getDate() where ";
            query = masterStatus.MstTableName is not null ? $"{query} mstTableName = @MstTableName" : string.Empty;
            query = masterStatus.CacheName is not null ? $"{query} CacheName = @CacheName" : string.Empty;

            var config = new DataDbConfigSettings<MasterStatus>
            {
                PlainQuery = query,
                Request = masterStatus,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.UpdateDataAsync<MasterStatus>(configSettings: config);
        }

        public async Task<int> InsertMasterStatusAsync(MasterStatus masterStatus)
        {
            var config = new DataDbConfigSettings<MasterStatus>
            {
                TableEnums = PBMaster.MasterStatus,
                Request = masterStatus,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.AddDataAsync<MasterStatus>(config);
        }


        public async Task<IEnumerable<MasterProductFeature>> GetMasterProfileFeatureDetailsAsync(MasterProductFeature masterProductFeature)
        {
            var query = " select distinct ProductCode, ekyc, " + masterProductFeature.AppChannelid is not null ? " appChannelid," : string.Empty + " MinFPCaptureCount	,FPUploadCount	,FPType	,ThresholdValue	,FPCompressionType,	FaceDetection,"
                             + " MinorCustomerAllowed	,MinorNomineeAllowed	,ImageResolution	,InitialFunding	,ChannelID	,Version " +
                             " ,ISNULL(MaxBalance,0) MaxBalance	,ISNULL(TotalDebitAmountPerMonth,0) TotalDebitAmountPerMonth " +
                             "   ,ISNULL(TotalCreditAmountPerMonth,0) TotalCreditAmountPerMonth	,ISNULL(MaxWithdrawal,0) MaxWithdrawal,ISNULL(IsDebitCard,0) IsDebitCard,ISNULL(DebitCardID,0) DebitCardID,ISNULL(LendingParam,'') LendingParam, ISNULL(NEFTAmount,'') NEFTAmount, " +
                             " ProductBenefit, mstProductType.AccountNo,mstProductFeature.AuthTypeID,mstProductFeature.AuthTypeName,mstProductFeature.ServiceCharge,mstProductFeature.Mode  " +
                             " from mstProductFeature with (nolock) inner join mstProductType with (nolock) on mstProductType.type=mstProductFeature.ProductCode " +
                             " where mstProductFeature.status=1 and ChannelID=@ChannelID " + masterProductFeature.AppChannelid is not null ? " and appChannelid=@AppChannelid" : string.Empty;


            query = $"{query}" + masterProductFeature.ProductCode is not null ? " and ProductCode in (@ProductCode)  and LendingFlag = 1 " : " and LendingFlag = 0";
            query = $"{query}" + masterProductFeature.Ekyc is not null ? masterProductFeature.Ekyc is true ? " and ekyc= 1 " : " and ekyc= 0 " : string.Empty;


            var config = new DataDbConfigSettings<MasterProductFeature>
            {
                PlainQuery = query,
                Request = masterProductFeature,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<MasterProductFeature, MasterProductFeature>(configSettings: config);
        }

        public async Task<IEnumerable<MasterProfileControl>> GetMasterProfileControlAsync(MasterProfileControl masterProfileControl)
        {
            var query = "  select c.TabControlID,c.ControlName,c.ControlID ,c.ControlDesc,c.TabID ,case m.Displayable when 0 then 'N' when 1 then 'Y' end Displayable " +
                                " ,case m.Editable when 0 then 'N' when 1 then 'Y' end Editable,case m.Mandatory when 0 then 'N' when 1 then 'Y' end Mandatory " +
                                " ,case m.KYCMandatory when 0 then 'N' when 1 then 'Y' end KYCMandatory,m.FieldType ,m.DataType," +
                                " case f.ekyc when 0 then 'N' when 1 then 'Y' end ekyc,ISNULL(m.FieldLength,0) FieldLength " +
                                " ,ISNULL(m.FieldMinLength,0) FieldMinLength,ISNULL(m.FieldMaxLength,0) FieldMaxLength ," +
                                " Isnull(m.FieldMinValue,0) FieldMinValue ,ISNULL(m.FieldMaxValue,0) FieldMaxValue,m.RequiredMaster ,m.Status " +
                                " ,m.KYCFlag,m.RFU1,m.RFU2,ProductBenefit,m.EditableAddOn,m.DisplayableADDOn from mstProductTabCtrlMap m with (nolock) " +
                                " INNER JOIN  mstTabControl c with (nolock) on m.TabControlID = c.TabControlID " +
                                " INNER JOIN mstProductFeature f with (nolock) ON m.ProductType= f.ProductCode and m.ChannelID =f.ChannelID " +
                                " where m.status=1 and m.channelID=@ChannelID ";

            query = $"{query}" + masterProfileControl.AppChannelid is not null ? "  and m.appChannelid = @AppChannelid " : string.Empty;
            query = $"{query}" + masterProfileControl.ProductCode is not "" and not null ? " and ProductCode in (@ProductCode) " : string.Empty;
            query = $"{query}" + masterProfileControl?.Ekyc is not null && masterProfileControl?.Ekyc is true ? " and ekyc= 1 and (KYCFlag='12' or KYCFlag='1') " : " and ekyc= 0 and (KYCFlag='12' or KYCFlag='2') ";
            query = $"{query}  order by ekyc desc";

            var config = new DataDbConfigSettings<MasterProfileControl>
            {
                PlainQuery = query,
                Request = masterProfileControl,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<MasterProfileControl, MasterProfileControl>(configSettings: config);




        }

        public async Task<IEnumerable<SequenceMapping>> GetSequencesAsync()
        {
            var query = " ;WITH x AS " +
                      " (  SELECT s.SeqMapId,c.SequenceId,ExistingProductType,c.SequenceOrder,s.NewProductType,c.Label,Mode,RFU,RFU1,RFU2,s.LendingParam ," +
                      " s.Status, case s.EkycFlag when 0 then 'N' when 1 then 'Y' end EkycFlag,s.AuthTypeId  FROM dbo.mstSequenceMapping AS s with (nolock) " +
                      " CROSS APPLY dbo.SplitStrings_XML(s.SequenceList, default) AS f  left JOIN dbo.mstsequence AS c with (nolock) ON f.item = c.SequenceID where s.Status=1 " +
                      " )" +
                      " SELECT SeqMapId,Mode,ISNULL(RFU,'NA') RFU,ISNULL(RFU1,'NA') RFU1,ISNULL(RFU2,'NA') RFU2,ISNULL(LendingParam,'NA')AS LendingParam,ISNULL(ExistingProductType,'NA') ExistingProductType,ISNULL(NewProductType,'NA') NewProductType,EkycFlag,ISNULL(AuthTypeId,'NA') AuthTypeId,STUFF((SELECT '|'+convert(varchar,SequenceId) +'~'+ Label +'~'+ EkycFlag  FROM x As x2 " +
                      " WHERE x2.SeqMapId = x.SeqMapId ORDER BY SeqMapId FOR XML PATH,TYPE).value(N'.[1]',N'varchar(max)'), 1, 1, '') As Sequencelist " +
                      " FROM x GROUP BY ExistingProductType,SeqMapId,NewProductType,EkycFlag,Mode,RFU,RFU1,RFU2,AuthTypeId,LendingParam ";

            var config = new DataDbConfigSettings<dynamic>
            {
                PlainQuery = query,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<dynamic, SequenceMapping>(configSettings: config);

        }


        public async Task<IEnumerable<RoleMenu>> GetRoleBasedMenuAsync(int userType, int channelId)
        {

            var parameter = new
            {
                userType = userType,
                channelID = channelId
            };

            var query = "select mstMenu.MenuID,mstMenu.MenuDescription,mstMenu.MenuParent,mstMenu.MenuUrl,mstMenu.MenuPosition,mstMenu.OnClickFunction,mstMenu.Menu_cssClass,mstMenu.Menu_cssIconClass,mstMenu.FormID, mstMenu.MenuIdKey " +
                "  from mstMenu with (nolock)  INNER JOIN mstRoleMenu with (nolock) ON mstMenu.MenuID=mstRoleMenu.MenuID INNER JOIN mstuserType ON  mstRoleMenu.UserType =  mstuserType.UserTypeId" +
                " INNER JOIN mstChannel with (nolock) ON mstChannel.ChannelID = mstMenu.ChannelID " +
                " where mstRoleMenu.status = 1 and  mstRoleMenu.UserType  = @userType and mstChannel.ChannelID = @channelID order by mstMenu.MenuPosition";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            var data = await _dataDbConfigurationService.GetDatasAsync<object, RoleMenu>(config);



        }

    }
}
