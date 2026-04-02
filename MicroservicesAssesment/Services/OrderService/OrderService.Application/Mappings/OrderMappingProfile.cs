using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using OrderService.Application.DTOs;
using OrderService.Domain.Entities;

namespace OrderService.Application.Mappings;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.SubTotal, o => o.MapFrom(s => s.SubTotal));
    }
}
