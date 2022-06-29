using LoginService.Application.Contracts.Identity;
using LoginService.Application.Models;
using System;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Login.Identity.Service
{
    public class ProcessIdentityService : IProcessIdentityService
    {

        private readonly IAuthenticationService _authenticationService;
        public ProcessIdentityService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task IdentityAsync(AuthenticationRequest authenticationRequest)
        {

            if (authenticationRequest is null)
            {
                //return outresponse empty 
            }
            else
            {
                if (authenticationRequest.IsEncrypt)
                {
                    var requestData = authenticationRequest.RequestId.ToJsonDeSerialize<dynamic>();
                    string reqData = Convert.ToString(requestData.RequestData);
                    string sessionId = Convert.ToString(requestData.SessionId);
                    var decriptData = reqData.ToDecryptOpenSSL(sessionId);
                    authenticationRequest.RequestData = decriptData;
                }

                //write log 

                switch (authenticationRequest.MethodId)
                {

                    case 1:
                        _authenticationService.AuthenticateAsync(authenticationRequest);
                        break;

                    default:
                        break;
                }


            }



            throw new NotImplementedException();
        }
    }
}
