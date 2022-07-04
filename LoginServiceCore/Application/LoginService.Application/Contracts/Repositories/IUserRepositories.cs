using Common.Application.Model;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Repositories
{
    public interface IUserRepositories
    {
        Task<IEnumerable<UserRestriction>> GetUserRestricationAsync(FisUserPasswordValidateRequest fisUserPasswordValidateRequest, int latlong);

        Task<Reasons> GetReasonsAsync(string reasonsCode);


    }
}
