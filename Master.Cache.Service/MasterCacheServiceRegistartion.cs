using Master.Cache.Service.MasterCache;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Cache.Service
{
    public static class MasterCacheServiceRegistartion
    {
        public static void AddMasterCacheService(this IServiceCollection services)
        {
            services.AddTransient<IMasterCacheService, MasterCacheService>();
        }
    }
}
