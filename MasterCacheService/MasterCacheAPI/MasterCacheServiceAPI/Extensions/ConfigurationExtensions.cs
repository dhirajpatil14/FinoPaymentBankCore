using Common.Application.Model.Settings;
using HotRod.Cache.Settings;
using Loggers.Logs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasterCacheServiceAPI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void UseConfigurationExtension(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<AppSettings>(_config.GetSection("AppSettings"));
            services.Configure<CacheSettings>(_config.GetSection("CacheSettings"));
            services.Configure<LoggingSettings>(_config.GetSection("LoggingSettings"));
        }
    }
}
