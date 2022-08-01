using Common.Application.Model;
using Common.Application.Model.Settings;
using HotRod.Cache.Connector.Application;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Utility.Extensions;

namespace HotRod.Cache.Connector
{
    public class CacheConnector : ICacheConnector
    {
        private readonly AppSettings _appSettings;
        private readonly HotRodCache _hotRodCache;
        private readonly ICacheRepositories _cacheRepositories;


        public CacheConnector(IOptions<AppSettings> appSettings, HotRodCache hotRodCache, ICacheRepositories cacheRepositories)
        {
            _appSettings = appSettings.Value;
            _hotRodCache = hotRodCache;
            _hotRodCache.Initlization(_hotRodCache._cacheSettings.CacheSessionContainerName);
            _cacheRepositories = cacheRepositories;
        }
        public async Task<string> PutCacheAsync(string cacheName, string value)
        {
            return await _hotRodCache.PutCacheAsync(cacheName, value);
        }
        public async Task<string> GetCache(string cacheName, bool masterVersion)
        {
            //need to work on this method 
            var cacheValue = _appSettings.IsSession is 1 || _appSettings.IntByCache is 1 ? await _hotRodCache.GetCacheAsync(cacheName) : null;
            cacheValue = cacheValue is null && _appSettings.IsSession is not 1 && _appSettings.IntByCache is not 1 ? (await _cacheRepositories.GetMasterByCacheNameAsync(cacheName)).Value : cacheValue;

            var versions = await GetCacheVersion(cacheName);

            if (cacheValue is null && _appSettings.IsSession is not 1 && _appSettings.IntByCache is not 1)
                return cacheValue;
            else
                await _cacheRepositories.UpdateMasterCacheAsync(cacheName, cacheValue, versions);

            if (masterVersion)
            {
                var data = cacheValue is "" or null ? await _cacheRepositories.GetMasterByCacheNameAsync(cacheName) : null;
                if (data is not null && data?.Version is not null)
                {
                    await PutCacheAsync(data?.MasterCacheKey, data?.Value);
                    return data?.Value;
                }

            }
            return cacheValue;
        }

        public async Task<string> GetCacheVersion(string cacheName)
        {
            var cache = await _cacheRepositories.GetMasterByCacheNameAsync(cacheName);
            if (cache is not null && cache?.Version is not "0")
            {
                return cache?.Version.ToString();
            }
            else
            {
                string version = await _hotRodCache.GetVersionAsync(cacheName);
                await _cacheRepositories.UpdateMasterCacheByMasterKey(version, cacheName);
                return version;
            }
            //var cache = _appSettings.IntByCache is 1 ? await _masterCacheService.GetMasterByCacheNameAsync(cacheName) : null;
            //var version = string.Empty;
            //if (cache is null && _appSettings.IntByCache is not 1)
            //{
            //    cache = await _masterCacheService.GetMasterByCacheNameAsync(cacheName);
            //    if (cache is not null && cache.Version is not "0")
            //    {
            //        return cache?.Version.ToString();
            //    }
            //    else
            //    {
            //        version = await _hotRodCache.GetVersionAsync(cacheName);
            //        await _masterCacheService.UpdateMasterCacheByMasterKey(version, cacheName);

            //        return version;
            //    }
            //}
            //return cache?.Version.ToString();

        }

        public async Task<FosAppVersion> GetFOSApplicationVersion(string authenticator, string cacheName)
        {
            var data = await _cacheRepositories.GetFOSApplicationVersionAsync(authenticator);
            if (data is not null)
            {
                await _hotRodCache.PutCacheAsync(cacheName, data.ToJsonSerialize());
            }

            return data;
        }

        public async Task<MobileVersion> GetMobileVersionAsync(string cacheName)
        {
            var data = await _cacheRepositories.GetMobileVersionAsync();
            if (data is not null)
            {
                await PutCacheAsync(cacheName, data.ToJsonSerialize());
            }
            return data;
        }

        public async Task<int> RemoveCacheAuditAsync(CacheAuditTrail cacheAuditTrail)
        {
            var oldCache = await _hotRodCache.GetCacheAsync(cacheAuditTrail.CacheKey);
            cacheAuditTrail.OldData = oldCache;
            var id = await _cacheRepositories.InsertCacheAuditTrailLog(cacheAuditTrail);
            await _hotRodCache.RemoveCacheAsync(cacheAuditTrail.CacheKey);
            return id;
        }


        public async Task<bool> RemoveAsync(string cacheName)
        {
            var isRemove = await _hotRodCache.RemoveCacheAsync(cacheName);
            return isRemove.Item2;
        }


        /// <summary>
        /// PutCacheAuditWithOutIncVer
        /// </summary>
        /// <param name="cacheName"></param>
        /// <param name="data"></param>
        /// <param name="auditTrailId"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task<bool> PutCacheAuditWithOutVersion(string cacheName, string data, int auditTrailId, string ipAddress, bool isIncVersion = false)
        {
            await PutCacheAsync(cacheName, data);
            var versionResult = await _cacheRepositories.GetMasterByCacheNameAsync(cacheName);
            var versionId = versionResult is not null ? string.IsNullOrEmpty(versionResult?.Version) ? 0 : isIncVersion ? Convert.ToInt64(versionResult?.Version) + 1 : Convert.ToInt64(versionResult?.Version) : 1;
            var isUpdated = await _cacheRepositories.UpdateMasterCacheAsync(cacheName, data, versionId.ToString());
            var isInsertorUpdateAudit = auditTrailId is not 0 ? await _cacheRepositories.UpdateCacheAuditTrailLog(new CacheAuditTrail { CacheKey = cacheName, NewData = data, Id = auditTrailId }) : await _cacheRepositories.InsertCacheAuditTrailLog(new CacheAuditTrail { CacheKey = cacheName, IpAddress = ipAddress, NewData = data, OldData = string.Empty, UpdatedDate = DateTime.Now });
            return true;
        }

        public async Task<bool> PutCacheMasterAsync(string cacheName, string data)
        {

            await PutCacheAsync(cacheName, data);

            var cache = await _cacheRepositories.GetMasterByCacheNameAsync(cacheName);
            var versionId = cache is not null ? Convert.ToInt32(cache?.Version) : 1;
            await _cacheRepositories.UpdateMasterCacheAsync(cacheName, data, versionId.ToString());
            return true;
        }


    }
}
