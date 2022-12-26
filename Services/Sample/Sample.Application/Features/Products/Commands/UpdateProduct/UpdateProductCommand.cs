using Common.Wrappers;
using MediatR;

namespace Sample.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<Unit>>
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
