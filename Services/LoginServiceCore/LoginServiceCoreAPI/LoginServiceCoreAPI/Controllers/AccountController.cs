using Common.Application.Interface;
using Common.Application.Model;
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
            return Ok(await _processIdentityService.IdentityAsync(authenticationRequest));
        }

        //[HttpPost("authenticate")]
        //public async Task<IActionResult> AuthenticationENAsync(AuthenticationEnRequest enRequest)
        //{
        //    return Ok(await _processIdentityService.IdentityPayloadAsync(enRequest));
        //}

    }
}
