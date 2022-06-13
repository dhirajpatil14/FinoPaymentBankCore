﻿using AspNet.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Application.Features.Products.Commands.UpdateProduct;
using System;
using System.Threading.Tasks;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPut("updateProducts")]
        public async Task<IActionResult> UpdateProductsAsync(UpdateProductCommand command)
        {
            _logger.LogInformation("Call UpdateProductsAsync Method");
            return Ok(await Mediator.Send(command));
        }



    }
}
