using Data.Db.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Db.Service
{
    public static class DataDbConfigurationExtension
    {
        public static void AddDataDbConfigurationLayer(this IServiceCollection services)
        {

            services.AddTransient<IDataDbConfigurationService, DataDbConfigurationService>();
        }
    }
}
