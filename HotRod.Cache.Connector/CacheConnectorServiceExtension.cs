using HotRod.Cache.Connector.Application;
using HotRod.Cache.Connector.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HotRod.Cache.Connector
{
    public static class CacheConnectorServiceExtension
    {
        public static void AddCacheConnectorServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<ICacheRepositories, CacheRepositories>();
            services.AddTransient<ICacheConnector, CacheConnector>();
        }
    }
}
