using Common.Wrappers;
using System.Threading.Tasks;
using WebApi.Services.Settings;

namespace WebApi.Services
{
    public interface IWebApiRequestService
    {
        Task<Response<T>> GetAsync<T, T1>(WebApiRequestSettings<T1> webApiRequestSettings, string message = "");
        Task<Response<T>> PostAsync<T, T1>(WebApiRequestSettings<T1> webApiRequestSettings, string message = "");
    }
}
