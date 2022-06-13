using Microsoft.Extensions.DependencyInjection;

namespace HotRod.Cache
{
    public static class CacheServiceExtension
    {
        public static void AddCacheServiceLayer(this IServiceCollection services)
        {
            services.AddSingleton<HotRodCache>();
        }
    }
}
