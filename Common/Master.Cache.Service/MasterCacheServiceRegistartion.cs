﻿using Master.Cache.Service.MasterCache;
using Master.Cache.Service.MasterCache.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Cache.Service
{
    public static class MasterCacheServiceRegistartion
    {
        public static void AddMasterSharedCacheService(this IServiceCollection services)
        {

            services.AddTransient<IMasterCacheRepositories, MasterCacheRepositories>();
            services.AddTransient<IMasterCacheService, MasterCacheService>();
        }
    }
}
