using HotRod.Cache.MasterCacheDictionary;
using HotRod.Cache.Settings;
using Infinispan.Hotrod.Core;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace HotRod.Cache
{
    public class HotRodCache
    {
        private Cache<string, string> Cache;

        private readonly MasterCachesDictionary _masterCachesDictionary;

        public readonly CacheSettings _cacheSettings;
        public HotRodCache(IOptions<CacheSettings> cacheSettings, MasterCachesDictionary masterCachesDictionary)
        {
            _cacheSettings = cacheSettings.Value;
            _masterCachesDictionary = masterCachesDictionary;
            ConnectAsync();
        }

        private readonly InfinispanDG InfinispanDG = new();

        #region Add Cache Server
        /// <summary>
        /// Add Cache Server 
        /// </summary>
        /// <param name="serverName">server ip address</param>
        /// <param name="port">server port</param>
        /// <param name="cacheName">cache name</param>
        protected void ConnectAsync()
        {
            InfinispanDG.AddHost(_cacheSettings.CacheServerName, _cacheSettings.CacheServerPort, false);

            _ = InfinispanDG.ForceReturnValue;
        }
        public void Initlization(string ContainerName)
        {

            var km = new StringMarshaller();
            var vm = new StringMarshaller();
            Cache = InfinispanDG.newCache(km, vm, ContainerName);
            Cache.ForceReturnValue = true;
        }
        #endregion

        #region Get Cache Value
        /// <summary>
        /// Get Cache Value
        /// </summary>
        /// <param name="key">using key get value</param>
        /// <returns></returns>
        public async Task<string> GetCacheAsync(string key)
        {
            string cacheData = await _masterCachesDictionary.GetMasterCacheAsync(key);
            if (cacheData is null)
            {
                cacheData = await Cache.Get(key);
                if (!string.IsNullOrEmpty(cacheData))
                {
                    await _masterCachesDictionary.SetMasterCacheAsync(key, cacheData);
                }
            }
            return cacheData;
        }
        #endregion

        #region Put or Save Cache Value
        /// <summary>
        /// Set Cache Value
        /// </summary>
        /// <param name="key">using key set value</param>
        /// <param name="value">key of value</param>
        /// <returns>return key of value</returns>
        public async Task<string> PutCacheAsync(string key, string value)
        {
            string cacheData = await _masterCachesDictionary.GetMasterCacheAsync(key);

            if (string.IsNullOrEmpty(cacheData))
            {
                await _masterCachesDictionary.SetMasterCacheAsync(key, cacheData);
            }

            return await Cache.Put(key, value);
        }
        #endregion

        #region Get Version
        /// <summary>
        /// Get Cache Value
        /// </summary>
        /// <param name="key">using key get value</param>
        /// <returns></returns>
        public async Task<string> GetVersionAsync(string key)
        {
            var version = await Cache.GetWithVersion(key);
            return version.Version.ToString();
        }
        #endregion

        #region Remove  Cache Value
        /// <summary>
        /// Set Cache Value
        /// </summary>
        /// <param name="key">using key set value</param>
        /// <returns>return key of value and Remove Flg</returns>
        public async Task<(string, bool)> RemoveCacheAsync(string key)
        {
            var remove = await Cache.Remove(key);
            return remove;
        }
        #endregion

    }
}
