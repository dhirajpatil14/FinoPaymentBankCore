using Data.Db.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Db.Service.Interface
{
    public interface IDataDbConfigurationService
    {
        Task<int> AddDataAsync<TRequest>(DataDbConfigSettings<TRequest> configSettings);

        Task<IEnumerable<TResponce>> GetDataAsync<TRequest, TResponce>(DataDbConfigSettings<TRequest> configSettings);
    }
}
