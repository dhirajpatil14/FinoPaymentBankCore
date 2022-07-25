using Common.Application.Model;
using Master.Cache.Service.MasterCache.Model;
using System.Threading.Tasks;

namespace MasterCacheService.Application.Contracts.ServiceContarct
{
    public interface IMasterCacheApplicationService
    {
        Task<OutResponse> MasterServiceCacheAsync(CacheRequest cacheRequest);

    }
}
