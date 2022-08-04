using Master.Cache.Service.MasterCache.DTo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache.Repositories
{
    public interface IMasterCacheRepositories
    {
        Task<dynamic> ExecuteQueryAsync(string query);

        Task<IEnumerable<MasterStatus>> GetMasterVersionAsync(MasterStatus masterStatus);

        Task<int> UpdateMasterStatusAsync(MasterStatus masterStatus);

        Task<int> InsertMasterStatusAsync(MasterStatus masterStatus);


        Task<IEnumerable<MasterProductFeature>> GetMasterProfileFeatureDetailsAsync(MasterProductFeature masterProductFeature);

        Task<IEnumerable<MasterProfileControl>> GetMasterProfileControlAsync(MasterProfileControl masterProfileControl);

        Task<IEnumerable<SequenceMapping>> GetSequencesAsync();

        Task<IEnumerable<RoleMenu>> GetRoleBasedMenuAsync(int userType, int channelId);

        Task<(IEnumerable<RoleMenu> rolesMenu, IEnumerable<MobileRoleMenu> mobileRoleMenus)> GetRoleBasedMenuMultipalAsync(int userType, int channelId);


        Task<(ProfileType profileType, IEnumerable<ProfileTransaction> profileTransactions)> ProfileTypeDictionaryAsync(string userType, string channelId, string lendingBankName = null, string distinctField = null, string[] orderByField = null);

        Task<IEnumerable<ProductTranscation>> GetProductTranscationData(string leadingBankType, string userTypeId, string isFinancial);


    }
}
