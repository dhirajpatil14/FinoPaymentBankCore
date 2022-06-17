using Moq;
using Sample.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Application.UnitTests.Mocks
{
    public class ProductRepositoryMocks
    {
        public static Mock<IProductRepository> GetProductReposotory()
        {
            var productList = new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product
                {
                    Created = new System.DateTime(),
                    CreatedBy = "1",
                    Description ="Test 1",
                    LastModified = new System.DateTime(),
                    LastModifiedBy ="1",
                    Price = 125,
                    ProductCode ="Test 11",
                    Id = 1
                },
                new Domain.Entities.Product
                {
                    Created = new System.DateTime(),
                    CreatedBy ="2",
                    Description = "Test 2",
                    LastModified = new System.DateTime(),
                    LastModifiedBy ="2",
                    Price =130,
                    ProductCode ="Test 22",
                    Id =2
                }
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(productList);

            mockProductRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return productList.SingleOrDefault(x => x.Id == Id);
            });

            mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Product>())).ReturnsAsync((Domain.Entities.Product Product) =>
            {
                productList.Add(Product);
                return Product;

            });

            mockProductRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.Product>())).Callback((Domain.Entities.Product Product) =>
            {
                productList.Remove(Product);
            });

            mockProductRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Entities.Product>())).Callback((Domain.Entities.Product Product) =>
            {
                var oldProduct = productList.First(x => x.Id == Product.Id);
                var index = productList.IndexOf(oldProduct);
                if (index != -1)
                    productList[index] = Product;
            });

            return mockProductRepository;
        }
    }
}
