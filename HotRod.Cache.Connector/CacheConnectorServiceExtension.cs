using Microsoft.Extensions.DependencyInjection;

namespace HotRod.Cache.Connector
{
    public static class CacheConnectorServiceExtension
    {
        public static void AddCacheConnectorServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<ICacheConnector, CacheConnector>();

        }
    }
}
