using Common.Application;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {


        public ProductRepository()
        {
        }

        public Task<Product> GetProductByName(string productName)
        {
            throw new System.NotImplementedException();
        }



    }
}
