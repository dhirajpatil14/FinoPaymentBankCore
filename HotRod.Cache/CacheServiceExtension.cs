using HotRod.Cache.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotRod.Cache
{
    public static class CacheServiceExtension
    {
        public static void AddCacheServiceLayer(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<CacheSettings>(Configuration.GetSection("CacheSettings"));
            services.AddSingleton<HotRodCache>();
        }
    }
}
