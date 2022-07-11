using Common.Application.Model;
using Common.Application.Model.Settings;
using Microsoft.Extensions.Options;
using Shared.Services.MasterCache;
using SQL.Helper;
using System.Threading.Tasks;
using Utility.Extensions;

namespace HotRod.Cache.Connector
{
    public class CacheConnector : ICacheConnector
    {
        private readonly AppSettings _appSettings;

        private readonly HotRodCache _hotRodCache;



        private readonly IMasterCacheService _masterCacheService;

        public CacheConnector(IOptions<AppSettings> appSettings, IOptions<SqlConnectionStrings> sqlConnectionStrings, HotRodCache hotRodCache, IMasterCacheService masterCacheService)
        {
            _appSettings = appSettings.Value;
            _hotRodCache = hotRodCache;
            _masterCacheService = masterCacheService;

        }

        public async Task<string> GetCache(string cacheName, bool masterVersion)
        {
            //need to work on this method 
            var cacheValue = _appSettings.IsSession is 1 || _appSettings.IntByCache is 1 ? await _hotRodCache.GetCacheAsync(cacheName) : null;
            cacheValue = cacheValue is null && _appSettings.IsSession is not 1 && _appSettings.IntByCache is not 1 ? (await _masterCacheService.GetMasterByCacheNameAsync(cacheName)).Value : await _hotRodCache.GetCacheAsync(cacheName);

            var versions = await GetCacheVersion(cacheName);

            if (cacheValue is null && _appSettings.IsSession is not 1 && _appSettings.IntByCache is not 1)
                return cacheValue;
            else
                await _masterCacheService.UpdateMasterCacheAsync(cacheName, cacheValue, versions);

            if (masterVersion)
            {
                var data = cacheValue is "" or null ? await _masterCacheService.GetMasterByCacheNameAsync(cacheName) : null;
                if (data is not null)
                {
                    await _hotRodCache.PutCacheAsync(data?.MasterCacheKey, data?.Value);
                    return data?.Value;
                }

            }
            return cacheName;
        }

        public async Task<string> GetCacheVersion(string cacheName)
        {
            var cache = _appSettings.IntByCache is 1 ? await _masterCacheService.GetMasterByCacheNameAsync(cacheName) : null;
            var version = string.Empty;
            if (cache is null && _appSettings.IntByCache is not 1)
            {
                cache = await _masterCacheService.GetMasterByCacheNameAsync(cacheName);
                if (cache is not null && cache.Version is not 0)
                {
                    return cache?.Version.ToString();
                }
                else
                {
                    version = await _hotRodCache.GetVersionAsync(cacheName);
                    await _masterCacheService.UpdateMasterCacheByMasterKey(version, cacheName);

                    return version;
                }
            }
            return cache?.Version.ToString();

        }

        public async Task<FosAppVersion> GetFOSApplicationVersion(string authenticator, string cacheName)
        {
            var data = await _masterCacheService.GetFOSApplicationVersionAsync(authenticator);
            if (data is not null)
            {
                await _hotRodCache.PutCacheAsync(cacheName, data.ToJsonSerialize());
            }

            return data;
        }

        public async Task<MobileVersion> GetMobileVersionAsync(string cacheName)
        {
            var data = await _masterCacheService.GetMobileVersionAsync();
            if (data is not null)
            {
                await _hotRodCache.PutCacheAsync(cacheName, data.ToJsonSerialize());
            }
            return data;
        }


    }
}
