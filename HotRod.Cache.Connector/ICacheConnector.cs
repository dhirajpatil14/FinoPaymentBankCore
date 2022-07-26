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
        Task<int> PutCacheAuditWithOutVersion(string cacheName, string data, int auditTrailId, string ipAddress);

    }
}
