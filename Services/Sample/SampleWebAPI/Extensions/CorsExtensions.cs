using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.API.Extensions
{
    public static class CorsExtensions
    {
        public static void UseCorsExtension(this IServiceCollection services, IConfiguration _config)
        {

            string Urls = _config.GetSection("URLWhiteListings").GetSection("URLs").Value;

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(Urls)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });



        }
    }
}
