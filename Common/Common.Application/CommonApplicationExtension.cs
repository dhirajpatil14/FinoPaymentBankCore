using Microsoft.Extensions.DependencyInjection;

namespace Common.Application
{
    public static class CommonApplicationExtension
    {
        public static void CommonApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        }
    }
}
