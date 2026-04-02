using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""));
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));
        CreateMap<CreateCategoryDto, Category>();
    }
}
