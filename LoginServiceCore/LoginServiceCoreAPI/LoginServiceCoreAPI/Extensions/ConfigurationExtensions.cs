using HotRod.Cache.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Domain;

namespace LoginServiceCoreAPI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void UseConfigurationExtension(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<AppSettings>(_config.GetSection("AppSettings"));
            services.Configure<CacheSettings>(_config.GetSection("CacheSettings"));
        }
    }
}
