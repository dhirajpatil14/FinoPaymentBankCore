using Common.Application.Interface;
using Common.Application.Model;
using LoginService.Application.Models;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Identity
{
    public interface IProcessIdentityService
    {
        Task<OutResponse> IdentityAsync(AuthenticationRequest authenticationRequest);
        Task<OutResponse> IdentityPayloadAsync(AuthenticationEnRequest enRequest);
    }
}
