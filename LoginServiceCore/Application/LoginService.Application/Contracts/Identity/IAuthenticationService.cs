﻿using Common.Application.Model;
using LoginService.Application.Models;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<OutResponse> ValidateUserAuthenticationAsync(AuthenticationRequest authenticationRequest);

        Task<OutResponse> ValidateUser(AuthenticationRequest authenticationRequest);
    }
}
