using Master.Cache.Service.MasterCache.Model;
using MasterCacheService.Application.Contracts.ServiceContarct;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MasterCacheServiceAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterCacheController : ControllerBase
    {
        private readonly IMasterCacheApplicationService _masterCacheApplicationService;
        public MasterCacheController(IMasterCacheApplicationService masterCacheApplicationService)
        {
            _masterCacheApplicationService = masterCacheApplicationService;
        }

        [HttpPost("mastercache")]
        public async Task<IActionResult> AuthenticationAsync(CacheRequest inRequest)
        {
            return Ok(await _masterCacheApplicationService.MasterServiceCacheAsync(inRequest));
        }
    }
}
