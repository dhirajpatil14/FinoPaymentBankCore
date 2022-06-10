using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Services
{
    public static class WebApiServiceRegistration
    {
        public static void AddWebApiService(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<IWebApiRequestService, WebApiRequestService>();
        }
    }
}
