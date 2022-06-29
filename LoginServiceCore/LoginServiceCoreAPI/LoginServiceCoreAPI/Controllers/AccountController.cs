using LoginService.Application.Contracts.Identity;
using LoginService.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginServiceCoreAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IProcessIdentityService _processIdentityService;

        public AccountController(IProcessIdentityService processIdentityService)
        {
            _processIdentityService = processIdentityService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticationAsync(AuthenticationRequest authenticationRequest)
        {
            await _processIdentityService.IdentityAsync(authenticationRequest);

            return Ok();
        }

    }
}
