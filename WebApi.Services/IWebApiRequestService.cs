using Common.Wrappers;
using System.Threading.Tasks;
using WebApi.Services.Settings;

namespace WebApi.Services
{
    public interface IWebApiRequestService
    {
        Task<Response<TResponse>> GetAsync<TResponse, TRequest>(WebApiRequestSettings<TRequest> webApiRequestSettings, string message = "");
        Task<Response<TResponse>> PostAsync<TResponse, TRequest>(WebApiRequestSettings<TRequest> webApiRequestSettings, string message = "");
    }
}
