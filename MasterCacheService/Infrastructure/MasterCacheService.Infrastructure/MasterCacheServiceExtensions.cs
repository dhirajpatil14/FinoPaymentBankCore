using Data.Db.Service;
using Loggers.Logs;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace MasterCache.Service
{
    public static class MasterCacheServiceExtensions
    {
        public static void AddMasterCacheService(this IServiceCollection service)
        {
            service.AddDataDbConfigurationLayer();

            service.AddLoggerLayer();

            service.AddMemoryService();

            service.AddMasterCacheService();
        }
    }
}
