using Microsoft.Extensions.DependencyInjection;
using Shared.Services.ESBURLService;

namespace Shared.Services
{
    public static class EsbMemoryServiceRegistration
    {
        public static void AddMemoryService(this IServiceCollection services)
        {
            services.AddSingleton<EsbUrlMemoryService>();
        }
    }
}
