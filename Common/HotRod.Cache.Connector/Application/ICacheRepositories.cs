using Common.Application.Model;
using System.Threading.Tasks;

namespace HotRod.Cache.Connector.Application
{
    public interface ICacheRepositories
    {
        Task<int> UpdateMasterCacheByMasterKey(string version, string masterCacheKey);
        Task<int> UpdateMasterCacheAsync(string cacheName, string cacheValue, string version);
        Task<MasterCaches> GetMasterByCacheNameAsync(string cacheName);
        Task<FosAppVersion> GetFOSApplicationVersionAsync(string authenticator);
        Task<MobileVersion> GetMobileVersionAsync();
        Task<int> InsertCacheAuditTrailLog(CacheAuditTrail cacheAuditTrail);

        Task<int> UpdateCacheAuditTrailLog(CacheAuditTrail cacheAuditTrail);

    }
}
