using Data.Db.Service;
using Loggers.Logs;
using Microsoft.Extensions.DependencyInjection;
using ServiceRequest.Application.Contracts.Identity;
using ServiceRequest.Identity.Service;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Services;

namespace ServiceRequest.Identity
{
    public static class ServiceRequestServiceExtensions
    {
        public static void AddServiceRequestService(this IServiceCollection service)
        {
            service.AddWebApiService();

            service.AddDataDbConfigurationLayer();

            service.AddLoggerLayer();

            service.AddMemoryService();

            service.AddTransient<IProcessSSRService, ProcessSSRService>();

            service.AddTransient<ISaveServiceRequestService, SaveServiceRequestService>();
        }
    }
}
