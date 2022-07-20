using HotRod.Cache;
using Login.Identity;
using Login.Infrastructure;
using LoginService.Application;
using LoginServiceCoreAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQL.Helper;

namespace LoginServiceCoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSqlConnectionService(Configuration);

            services.AddSwaggerExtension();

            services.AddApiVersioningExtension();

            services.AddCacheServiceLayer();

            services.UseConfigurationExtension(Configuration);

            services.UseCorsExtension(Configuration);

            services.AddAuthentication();

            services.AddApplicationService();

            services.AddIdentityService();

            services.AddInfrastureService();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwaggerExtension();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseErrorHandlingMiddleware();

            app.UseJwtMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
