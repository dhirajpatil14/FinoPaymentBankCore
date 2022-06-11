using Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Application
{
    public static class SampleApplicationExtension
    {
        public static void AddSampleApplicationLayer(this IServiceCollection services)
        {

            services.AddApplicationBehaviourLayer();

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


        }
    }
}
