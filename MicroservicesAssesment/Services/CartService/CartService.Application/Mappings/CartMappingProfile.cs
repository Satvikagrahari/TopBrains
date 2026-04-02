using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CartService.Application.DTOs;
using CartService.Domain.Entities;

namespace CartService.Application.Mappings;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<Cart, CartDto>()
            .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.TotalPrice));
        CreateMap<CartItem, CartItemDto>()
            .ForMember(d => d.SubTotal, o => o.MapFrom(s => s.SubTotal));
    }
}
