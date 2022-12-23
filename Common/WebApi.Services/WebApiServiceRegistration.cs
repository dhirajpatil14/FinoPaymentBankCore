using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Services
{
    public static class WebApiServiceRegistration
    {
        public static void AddWebApiService(this IServiceCollection services)
        {
            services.AddScoped<IWebApiRequestService, WebApiRequestService>();
        }
    }
}
