using Common.Application.Model;
using LoginService.Application.Models;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<OutResponse> AuthenticateAsync(AuthenticationRequest authenticationRequest);

        Task RestrictUserAccessAsync();
    }
}
