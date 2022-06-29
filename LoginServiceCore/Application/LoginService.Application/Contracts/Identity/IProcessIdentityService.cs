using LoginService.Application.Models;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Identity
{
    public interface IProcessIdentityService
    {
        Task IdentityAsync(AuthenticationRequest authenticationRequest);
    }
}
