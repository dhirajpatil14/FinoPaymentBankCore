using Common.Application.Model.Settings;
using HotRod.Cache.Settings;
using Loggers.Logs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestCoreAPI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void UseConfigurationExtension(this IServiceCollection service, IConfiguration _config)
        {
            service.Configure<AppSettings>(_config.GetSection("AppSettings"));
            service.Configure<CacheSettings>(_config.GetSection("CacheSettings"));
            service.Configure<LoggingSettings>(_config.GetSection("LoggingSettings"));
        }
    }
}
