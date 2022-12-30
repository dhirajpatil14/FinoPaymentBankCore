using HotRod.Cache.Connector;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRequest.Infrastructure
{
    public static class InfrastructureRegistartion
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddCacheConnectorServiceLayer();
            //services.AddTransient<>
        }
    }
}
