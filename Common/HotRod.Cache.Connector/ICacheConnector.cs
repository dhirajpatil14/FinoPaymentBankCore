using Common.Application.Model;
using System.Threading.Tasks;

namespace HotRod.Cache.Connector
{
    public interface ICacheConnector
    {
        Task<string> GetCache(string cacheName, bool masterVersion);
        Task<string> GetCacheVersion(string cacheName);
        Task<FosAppVersion> GetFOSApplicationVersion(string authenticator, string cacheName);
        Task<MobileVersion> GetMobileVersionAsync(string cacheName);

        Task<int> RemoveCacheAuditAsync(CacheAuditTrail cacheAuditTrail);
        Task<bool> RemoveAsync(string cacheName);


        Task<string> PutCacheAsync(string cacheName, string value);
        Task<bool> PutCacheAuditWithOutVersion(string cacheName, string data, int auditTrailId, string ipAddress, bool isIncVersion = false);


        Task<bool> PutCacheMasterAsync(string cacheName, string data);

    }
}
