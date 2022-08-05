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

        Task<OutResponse> ResetIndividualMasterCacheAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetIndividualMasterCacheWithOutIncrementVersionAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetProfileFeatureControlsAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetProfileFeatureControlsAppChannelAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetSequencesAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetSequencesAppChannelAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetPublicKeyAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetMenuByChannelAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetProfileTypeTransByChannelAsync(CacheRequest cacheRequest);
        Task<OutResponse> GetProfileTypeTransByChannelZipAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetProfileTypeTransByChannelLendingAsync(CacheRequest cacheRequest);
        Task<OutResponse> GetProductTransByChannelAsync(CacheRequest cacheRequest);

        Task<OutResponse> GetProductWiseTransactionsAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetMenuMasterByUserChannelAsync(CacheRequest cacheRequest);

        Task<OutResponse> ResetProfileMasterByUserChannelAsync(CacheRequest cacheRequest);

        Task<OutResponse> ClearCacheDataByKeyAsync(CacheRequest cacheRequest);

    }
}
