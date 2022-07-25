using Microsoft.Extensions.DependencyInjection;

namespace MasterCacheService.Application
{
    public static class MasterCacheServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
