using Common.Application.Model;
using Master.Cache.Service.MasterCache.Model;
using System.Threading.Tasks;

namespace MasterCacheService.Application.Contracts.ServiceContarct
{
    public interface IMasterCacheApplicationService
    {
        /// <summary>
        /// Master Cache Service
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        Task<OutResponse> MasterServiceCacheAsync(CacheRequest cacheRequest);

    }
}
