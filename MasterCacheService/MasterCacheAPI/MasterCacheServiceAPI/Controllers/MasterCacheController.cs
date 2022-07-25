using Common.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MasterCacheServiceAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterCacheController : ControllerBase
    {
        public MasterCacheController()
        {

        }

        [HttpPost("mastercache")]
        public async Task<IActionResult> AuthenticationAsync(InRequest inRequest)
        {
            return Ok();
        }
    }
}
