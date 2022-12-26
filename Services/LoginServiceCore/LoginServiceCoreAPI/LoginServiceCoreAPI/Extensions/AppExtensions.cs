using AspNet.Attributes;
using Microsoft.AspNetCore.Builder;

namespace LoginServiceCoreAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ErrorHandlerMiddleware>();
        }
        public static void UseJwtMiddleware(this IApplicationBuilder application)
        {
            // application.UseMiddleware<JwtMiddleware>();
        }


    }
}
