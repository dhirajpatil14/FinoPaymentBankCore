using Common.Application.Model;
using System.Threading.Tasks;

namespace Shared.Services.MasterCache
{
    public interface IMasterCacheService
    {
        Task<MasterCaches> GetMasterByCacheNameAsync(string cacheName);
        Task<int> UpdateMasterCacheByMasterKey(string version, string masterCacheKey);

        Task<FosAppVersion> GetFOSApplicationVersionAsync(string authenticator);

        Task<MobileVersion> GetMobileVersionAsync();

        Task<int> UpdateMasterCacheAsync(string cacheName, string cacheValue, string version);

    }
}
