using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Application.Contracts.Persistence;
using Sample.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                //throw new NotFoundException(nameof(Order), request.Id);
            }

            _mapper.Map(request, product, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(product);

            _logger.LogInformation($"Product {product.Id} is successfully updated.");

            return Unit.Value;

        }
    }
}
