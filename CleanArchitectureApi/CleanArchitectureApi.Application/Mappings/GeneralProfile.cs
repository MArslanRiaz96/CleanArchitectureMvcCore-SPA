using CleanArchitectureApi.Application.Features.Products.Commands.CreateProduct;
using CleanArchitectureApi.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using CleanArchitectureApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureApi.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
