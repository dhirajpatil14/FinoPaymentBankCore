﻿using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Master.Cache.Service.MasterCache.DTo;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                userType,
                channelId
            };

            string query;
            if (channelId == 2)
            {
                query = "select mstMenu.MenuID,mstMenu.MenuDescription,mstMenu.MenuParent,mstMenu.MenuUrl,mstMenu.MenuPosition,mstMenu.OnClickFunction,mstMenu.Menu_cssClass,mstMenu.Menu_cssIconClass,mstMenu.FormID, mstMenu.MenuIdKey " +
                    "  from mstMenu with (nolock)  INNER JOIN mstRoleMenu with (nolock) ON mstMenu.MenuID=mstRoleMenu.MenuID INNER JOIN mstuserType ON  mstRoleMenu.UserType =  mstuserType.UserTypeId" +
                    " INNER JOIN mstChannel with (nolock) ON mstChannel.ChannelID = mstMenu.ChannelID " +
                    " where mstRoleMenu.status = 1 and  mstRoleMenu.UserType  = @userType and mstChannel.ChannelID = @channelId order by mstMenu.MenuPosition";
            }
            else
            {
                query = " select distinct mstMenu.MenuID,mstMenu.MenuDescription,mstMenu.MenuUrl,mstMenu.Menu_cssClass,mstMenu.Menu_cssIconClass " +
                    " from mstMenu with (nolock) INNER JOIN mstRoleMenu with (nolock) ON mstMenu.MenuID=mstRoleMenu.MenuID  " +
                    " INNER JOIN mstuserType with (nolock) ON  mstRoleMenu.UserType =  mstuserType.UserTypeId " +
                    "  INNER JOIN mstChannel with (nolock) ON mstChannel.ChannelID = mstMenu.ChannelID " +
                    " INNER JOIN mstmenuPosition with (nolock) ON mstmenuPosition.menuPositionID = MobileMenuPosition " +
                    " where mstRoleMenu.status = 1" +
                    "  and  mstRoleMenu.UserType  = @userType and mstMenu.ChannelID = @channelId  ";
            }
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<object, RoleMenu>(config);
        }

        public async Task<(IEnumerable<RoleMenu> rolesMenu, IEnumerable<MobileRoleMenu> mobileRoleMenus)> GetRoleBasedMenuMultipalAsync(int userType, int channelId)
        {
            string query = string.Empty;

            var parameter = new
            {
                userType,
                channelId
            };

            if (channelId == 2)
            {
                query = "select mstMenu.MenuID,mstMenu.MenuDescription,mstMenu.MenuParent,mstMenu.MenuUrl,mstMenu.MenuPosition,mstMenu.OnClickFunction,mstMenu.Menu_cssClass,mstMenu.Menu_cssIconClass,mstMenu.FormID, mstMenu.MenuIdKey " +
                    "  from mstMenu with (nolock)  INNER JOIN mstRoleMenu with (nolock) ON mstMenu.MenuID=mstRoleMenu.MenuID INNER JOIN mstuserType ON  mstRoleMenu.UserType =  mstuserType.UserTypeId" +
                    " INNER JOIN mstChannel with (nolock) ON mstChannel.ChannelID = mstMenu.ChannelID " +
                    " where mstRoleMenu.status = 1 and  mstRoleMenu.UserType  = @userType and mstChannel.ChannelID = @channelId order by mstMenu.MenuPosition";
            }
            else
            {
                query = " select distinct mstMenu.MenuID,mstmenuPosition.menuPositionDesc,mstMenu.MenuDescription,mstMenu.MenuUrl,mstMenu.Menu_cssClass,mstMenu.Menu_cssIconClass " +
                    " from mstMenu with (nolock) INNER JOIN mstRoleMenu with (nolock) ON mstMenu.MenuID=mstRoleMenu.MenuID  " +
                    " INNER JOIN mstuserType with (nolock) ON  mstRoleMenu.UserType =  mstuserType.UserTypeId " +
                    "  INNER JOIN mstChannel with (nolock) ON mstChannel.ChannelID = mstMenu.ChannelID " +
                    " INNER JOIN mstmenuPosition with (nolock) ON mstmenuPosition.menuPositionID = MobileMenuPosition " +
                    " where mstRoleMenu.status = 1" +
                    "  and  mstRoleMenu.UserType  = @userType and mstMenu.ChannelID = @channelId  ";
            }

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };



            var data = await _dataDbConfigurationService.GetDatasAsync<object, RoleMenu>(config);
            IEnumerable<MobileRoleMenu> dataByGroup = channelId is not 2 ? data.GroupBy(p => p.MenuPositionDesc, (key, g) => new MobileRoleMenu
            {
                MenuPositionDesc = key,
                MobileMenu = g.ToList()

            }) : null;

            return (channelId is 2 ? data : null, dataByGroup);

        }

        public async Task<(ProfileType profileType, IEnumerable<ProfileTransaction> profileTransactions)> ProfileTypeDictionaryAsync(string userType, string channelId, string lendingBankName = null, string distinctField = null, string[] orderByField = null)
        {
            var parameter = new
            {
                userType,
                channelId,
                lendingBankName
            };

            var query = " select " + distinctField is not null ? $"distinct {distinctField}," : string.Empty + " mpt.ProfileTypeID,mpt.UserTypeID,mpt.TransactionTypeID,mpt.AuthTypeID,mpt.ChannelID,mpt.PerTransactionLimit," +
                                " mpt.MinTransLimit,mpt.MaxTransLimit,mpt.UserGrossLimit,mstTransactionType.TransactionTypeName,mstTransactionType.TransactionType," +
                                " mstTransactionAuthType.AuthTypeName,mstUserType.UserTypeName,isnull(mpt.Denomination,0) Denomination, " +
                                " mpt.ProductTypeID,mpt.status,mstTransactionType.IsFinancial,mpt.IsSplit,mpt.NoofRetry,mpt.FallBackAuth,mstTransactionType.DMSId, " +
                                " mstTransactionType.PageUrl,mpt.RFU,mpt.NoofFallBack,isnull(mpt.CashContributionStatus,0) CashContributionStatus," +
                                " isnull(mpt.IsOnlyWalkin,1) IsOnlyWalkin,mstTransactionType.TransactionTypeKey from mstProfileType mpt WITH (NOLOCK) " +
                                " INNER JOIN mstTransactionType WITH (NOLOCK) ON mpt.TransactionTypeID= mstTransactionType.TransactionTypeID " +
                                " INNER JOIN mstTransactionAuthType WITH (NOLOCK) ON mpt.AuthTypeID = mstTransactionAuthType.AuthTypeId " +
                                " INNER JOIN mstUserType WITH (NOLOCK) ON mpt.UserTypeID=mstUserType.UserTypeId " +
                                " where mpt.UserTypeID=@userType and ChannelID= @channelId and status ='true'" +
                                 lendingBankName is "" ? " and LendingBankId=0 " : lendingBankName is not "" and null ? " and  mpt.ProductTypeID = @lendingBankName" : ""
                                 + orderByField is not null ? $" order by " + string.Join(",", orderByField) : "";


            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            var profileTranscations = await _dataDbConfigurationService.GetDatasAsync<dynamic, ProfileTransaction>(configSettings: config);

            var profileTranscation = profileTranscations?.FirstOrDefault();

            var profileTypeData = new ProfileType { ChannelID = profileTranscation?.ChannelID, UserTypeID = profileTranscation?.UserTypeID, UserTypeName = profileTranscation?.UserTypeName, ProfileTransaction = profileTranscations };

            return (profileTypeData, profileTranscations);
        }


        public async Task<IEnumerable<ProductTranscation>> GetProductTranscationData(string leadingBankType, string userTypeId, string isFinancial)
        {
            var parameter = new
            {
                leadingBankType,
                userTypeId,
                isFinancial
            };

            StringBuilder builder = new();
            builder.Append("DROP TABLE #ProductList ");
            builder.Append("DECLARE @lendingbankType int =0 select @lendingbankType=Id from mstLendingBanks Where BankType= @leadingBankType ");
            builder.Append("select P.type,isnull(P.LendingBankId,0) LendingBankId INTO #ProductList  from mstProductType P ");
            builder.Append(" where p.LendingFlag=0 union (  select M.ProductTypeId,L.Id from mstLendingBanks L ");
            builder.Append(" inner join mstLendingBankProductMapping M WITH (NOLOCK) on L.id = M.LendingBankId ");
            builder.Append(" where L.Id = @lendingbankType )  order by LendingBankId select distinct mpt.UserTypeID, mpt.TransactionTypeID As Tid,");
            builder.Append(" mstTransactionType.TransactionDesc As Nm, mstTransactionType.TransactionType As Ty,mstUserType.UserTypeName, ");
            builder.Append(" isnull(mpt.Denomination,0) Denomination, mpt.ProductTypeID As ProductTypeId,mpt.status,mstTransactionType.IsFinancial As Fi ");
            builder.Append(" from mstProfileType mpt with (nolock) INNER JOIN mstTransactionType with (nolock) ");
            builder.Append(" ON mpt.TransactionTypeID= mstTransactionType.TransactionTypeID ");
            builder.Append(" INNER JOIN mstTransactionAuthType with (nolock) ON mpt.AuthTypeID = mstTransactionAuthType.AuthTypeId ");
            builder.Append(" INNER JOIN mstUserType with (nolock) ON mpt.UserTypeID=mstUserType.UserTypeId ");
            builder.Append(" INNER JOIN  #ProductList with (nolock) on mpt.ProductTypeID = #ProductList.[type] ");
            builder.Append(" where status ='true' and mpt.UserTypeID= @userTypeId and mpt.ChannelID=@channelId ");
            builder.Append(isFinancial is not "" ? " and isFinancial=@isFinancial" : string.Empty);

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = builder.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            var data = await _dataDbConfigurationService.GetDatasAsync<object, Transcation>(config);

            return data.GroupBy(p => p.ProductTypeId, (key, g) => new ProductTranscation
            {
                Pty = key,
                Transcations = g.ToList()
            });
        }
       
        public async Task<string> GetKeyValConnectionAsync(string connectionName, bool keyVal)
        {
            var parameter = new
            {
                connectionName,
            };

            string query;
            query = keyVal ?"select KeyVal from dbo.mstKeyConfiguration with (nolock) " : " select ConnectionString from dbo.tblConnectionStrings with (nolock) Where ConnectionStringName=@connectionName "; ;
            
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter is not null ? parameter : string.Empty,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            var connectionAndKeyVal = await _dataDbConfigurationService.GetDatasAsync<object, string>(configSettings: config);

            return connectionAndKeyVal?.FirstOrDefault();
        }
    }
}
