using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace SampleWebAPI
{
    public class Program
    {

        public IConfigurationRoot Configuration { get; set; }

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();



            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                Log.Information("Application Starting");
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "An error occurred seeding the DB");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
