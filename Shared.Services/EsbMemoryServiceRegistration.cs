using Common.Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services.ESBCBSMessageService;
using Shared.Services.ESBMessageService;
using Shared.Services.ESBURLService;
using Shared.Services.KYC;
using Shared.Services.MasterMessage;

namespace Shared.Services
{
    public static class EsbMemoryServiceRegistration
    {
        public static void AddMemoryService(this IServiceCollection services)
        {
            services.AddSingleton<EsbUrlMemoryService>();
            services.AddSingleton<EsbMessageService>();
            services.AddSingleton<EsbCbsMessageService>();
            services.AddSingleton<MasterMessageService>();
            services.AddTransient<IEkycAuaService, EkycAuaService>();
        }
    }
}
