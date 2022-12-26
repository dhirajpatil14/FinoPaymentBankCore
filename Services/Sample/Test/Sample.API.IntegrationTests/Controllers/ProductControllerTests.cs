using Common.Wrappers;
using MediatR;
using Sample.API.IntegrationTests.Base;
using Sample.Application.Features.Products.Commands.UpdateProduct;
using Shouldly;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility.Extensions;
using Xunit;

namespace Sample.API.IntegrationTests.Controllers
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public ProductControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Product_ReturnsSuccessResult()
        {
            var client = _factory.CreateDefaultClient();

            var @product = new UpdateProductCommand()
            {
                Id = 1,
                Description = "Test",
                Price = 120,
                ProductCode = "Test@123"
            };

            var eventJson = @product.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:44381/api/Product", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.ToJsonDeSerialize<Response<Unit>>();
            result.Succeeded.ShouldBeEquivalentTo(true);
            result.Data.ShouldBeOfType<Unit>();
            result.Errors.ShouldBeNull();
        }

    }
}
