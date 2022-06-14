using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.API.Extensions
{
    public static class CorsExtensions
    {
        public static void UseCorsExtension(this IServiceCollection services, IConfiguration _config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(_config.GetSection("AppSettings:CorsUrl").Value)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });



        }
    }
}
