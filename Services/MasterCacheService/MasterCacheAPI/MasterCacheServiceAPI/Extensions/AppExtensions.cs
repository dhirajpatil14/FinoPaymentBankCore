using AspNet.Attributes;
using Microsoft.AspNetCore.Builder;

namespace MasterCacheServiceAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
