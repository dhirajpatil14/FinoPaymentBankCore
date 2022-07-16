using Common.Application.Model;
using LoginService.Application.Models;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<OutResponse> ValidateUserAuthenticationAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> ValidateUserAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> VerifyUserIdAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> LogOutUserAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> GetAuthContextAsync(AuthenticationRequest authContextRequest);

        Task<OutResponse> GetEsbFpAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> ValidateTokenAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> UserUnlockAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> GetSecretQuestionAsync(AuthenticationRequest authenticationRequest);
    }
}
