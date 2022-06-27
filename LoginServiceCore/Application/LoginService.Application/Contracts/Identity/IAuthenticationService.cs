using LoginService.Application.Models;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task AuthenticateAsync(AuthenticationRequest authenticationRequest);




        Task RestrictUserAccessAsync();
    }
}
