using Master.Cache.Service.MasterCache.DTo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache.Repositories
{
    public interface IMasterCacheRepositories
    {
        Task<IEnumerable<MasterStatus>> GetMasterVersionAsync(string keyCategory = null);

        Task<dynamic> ExecuteQueryAsync(string query);




    }
}
