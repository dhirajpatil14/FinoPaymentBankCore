using Microsoft.Extensions.DependencyInjection;
namespace Loggers.Logs
{
    public static class LoggerServiceExtension
    {
        public static void AddLoggerLayer(this IServiceCollection services)
        {

            services.AddTransient<ILoggerService, LoggerService>();
        }
    }
}
