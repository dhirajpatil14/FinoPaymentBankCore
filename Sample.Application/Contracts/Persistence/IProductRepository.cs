using Common.Application;
using Sample.Domain.Entities;
using System.Threading.Tasks;

namespace Sample.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<Product> GetProductByName(string productName);
    }
}
