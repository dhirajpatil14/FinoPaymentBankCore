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

    }
}
