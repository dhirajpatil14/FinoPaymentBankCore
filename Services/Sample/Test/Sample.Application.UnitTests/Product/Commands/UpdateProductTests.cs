using AutoMapper;
using Moq;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Features.Products.Commands.UpdateProduct;
using Sample.Application.Mapping;
using Sample.Application.UnitTests.Mocks;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Application.UnitTests.Product.Commands
{
    public class UpdateProductTests
    {

        private readonly IMapper _mapper;

        private readonly Mock<IProductRepository> _mockProductRepository;

        public UpdateProductTests()
        {
            _mockProductRepository = ProductRepositoryMocks.GetProductReposotory();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidProduct_UpdateProduct()
        {
            var handler = new UpdateProductCommandHandler(_mapper, _mockProductRepository.Object);

            var productId = 2;

            var newProduct = new Domain.Entities.Product
            {

                Created = new System.DateTime().AddMinutes(2),
                CreatedBy = "2",
                Description = "This Update 12",
                LastModified = new System.DateTime().AddMinutes(3),
                LastModifiedBy = "2",
                Price = 165,
                ProductCode = "TEST12",
                Id = productId
            };

            var oldProduct = await _mockProductRepository.Object.GetByIdAsync(productId);

            await handler.Handle(new UpdateProductCommand()
            {
                Description = newProduct.Description,
                Price = newProduct.Price,
                ProductCode = newProduct.ProductCode,
                Id = newProduct.Id
            }, CancellationToken.None);

            var allProducts = await _mockProductRepository.Object.GetAllAsync();
            allProducts.Count.ShouldBe(2);
            allProducts.ShouldContain(oldProduct);
        }

    }
}
