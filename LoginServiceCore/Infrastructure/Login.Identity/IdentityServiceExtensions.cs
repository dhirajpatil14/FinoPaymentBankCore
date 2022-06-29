using Data.Db.Service;
using Loggers.Logs;
using Login.Identity.Service;
using LoginService.Application.Contracts.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;
using WebApi.Services;

namespace Login.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityService(this IServiceCollection service)
        {
            service.AddWebApiService();

            service.AddDataDbConfigurationLayer();

            service.AddLoggerLayer();

            service.AddMemoryService();

            service.AddTransient<IAuthenticationService, AuthenticationService>();

            service.AddTransient<IProcessIdentityService, ProcessIdentityService>();
        }
    }
}
