using Microsoft.Extensions.DependencyInjection;
using ServiceRequest.Application.Contracts.Identity;
using ServiceRequest.Identity.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRequest.Identity
{
    public static class ServiceRequestServiceExtensions
    {
        public static void AddServiceRequestService(this IServiceCollection service)
        {
            service.AddTransient<IProcessSSRService, ProcessSSRService>();
        }
    }
}
