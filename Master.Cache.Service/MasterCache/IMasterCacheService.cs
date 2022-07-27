using Common.Application.Model;
using Master.Cache.Service.MasterCache.Model;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache
{
    public interface IMasterCacheService
    {
        Task<OutResponse> GetMasterCacheCategoryAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetMasterCacheCategoryMobileAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetMasterCacheAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetMasterCacheZipAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMasterCacheByCategoryAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMasterCacheByCatgoryWithOutIncVersionAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMasterCacheByCatgoryForMobileAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMasterCacheByCategoryForMobileWithOutIncVersionAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMasterCacheAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMasterCacheWithOutVersionAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetVersionForMastersAsync(CacheRequest cacheRequest);


    }
}
