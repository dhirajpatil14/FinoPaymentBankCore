using AutoMapper;
using Common.Wrappers;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<Unit>>
    {
        private readonly IProductRepository _productRepository;
        // private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            //   _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }
        public async Task<Response<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                //throw new NotFoundException(nameof(Order), request.Id);
            }

            _mapper.Map(request, product, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(product);

            // _logger.LogInformation($"Product {product?.Id} is successfully updated.");

            return new Response<Unit>(Unit.Value, message: $"Product Successfully updated.");

        }
    }
}
