using Microsoft.Extensions.DependencyInjection;
using PBSecurity.Application;
using PBSecurity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBSecurity
{
    public static class PBSecurityServiceExtension
    {
        public static void AddPBSecurityServiceLayer(this IServiceCollection services)
        {
            services.AddSingleton<CommonEncryption>();
            services.AddTransient<IPBSecurityRepository, PBSecurityRepository>();
        }

    }
}
