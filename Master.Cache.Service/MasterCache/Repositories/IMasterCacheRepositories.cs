using Master.Cache.Service.MasterCache.DTo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache.Repositories
{
    public interface IMasterCacheRepositories
    {
        Task<dynamic> ExecuteQueryAsync(string query);

        Task<IEnumerable<MasterStatus>> GetMasterVersionAsync(string keyCategory = null, int? mBKeyCategory = null, string mstTable = null);

        Task<int> UpdateMasterStatusAsync(MasterStatus masterStatus);
    }
}
