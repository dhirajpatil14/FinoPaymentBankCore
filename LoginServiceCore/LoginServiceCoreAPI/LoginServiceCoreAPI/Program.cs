using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace LoginServiceCoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            BuildWebHost(args).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public static IWebHost BuildWebHost(string[] args) =>
             new WebHostBuilder()
                 .UseKestrel()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     var env = hostingContext.HostingEnvironment;
                     var parentDirectory = Directory.GetParent(env.ContentRootPath).Parent.Parent.FullName;
                     // find the shared folder in the parent folder
                     var sharedFolder = Path.Combine(parentDirectory, "", "Shared");

                     //load the SharedSettings first, so that appsettings.json overrwrites it
                     config
                          .AddJsonFile(Path.Combine(sharedFolder, "SharedSettings.json"), optional: true)
                          .AddJsonFile("appsettings.json", optional: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                     config.AddEnvironmentVariables();
                 })
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     logging.AddConsole();
                     logging.AddDebug();
                 })
                 .UseDefaultServiceProvider((ctx, opts) =>
                 {
                     opts.ValidateScopes = ctx.HostingEnvironment.IsDevelopment();
                 })
                 .UseStartup<Startup>()
                 .Build();


    }
}
