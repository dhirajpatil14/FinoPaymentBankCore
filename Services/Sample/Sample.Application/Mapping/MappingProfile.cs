﻿using AutoMapper;
using Sample.Application.Features.Products.Commands.UpdateProduct;
using Sample.Domain.Entities;

namespace Sample.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
