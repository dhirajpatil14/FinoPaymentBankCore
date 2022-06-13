using Common.Application;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Contracts.Persistence;
using Sample.Infrastructure.Repositories;

namespace Sample.Infrastructure
{
    public static class SampleInfrastructureExtension
    {
        public static void AddSampleInfrastructureLayer(this IServiceCollection services)
        {
            //services.AddDbContext<OrderContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.CommonApplicationLayer();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
