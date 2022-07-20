using AspNet.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
        public static void AddJsonCaseExtenstion(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);
        }

    }
}
