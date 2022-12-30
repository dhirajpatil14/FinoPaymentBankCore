using AspNet.Attributes;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestCoreAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void UseJWTMiddleware(this IApplicationBuilder application)
        {

        }
    }
}
