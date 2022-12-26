using HotRod.Cache.Connector;
using Login.Infrastructure.Repositories;
using LoginService.Application.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Login.Infrastructure
{
    public static class InfrastructureRegistartion
    {
        public static void AddInfrastureService(this IServiceCollection service)
        {
            service.AddCacheConnectorServiceLayer();
            service.AddTransient<IUserRepositories, UserRepositories>();

        }
    }
}
