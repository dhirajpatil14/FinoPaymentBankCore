using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceRequestCoreAPI.Extensions
{
    public static class CorsExtensions
    {
        public static void UseCorsExtension(this IServiceCollection service, IConfiguration _config)
        {
            string urls = _config.GetSection("URLWhiteListings").GetSection("URLs").Value;

            if(urls is not null)
            {
                service.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                    {
                        builder.WithOrigins(urls)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
                });
            }
        }
    }
}
