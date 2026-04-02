using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel.Enums;
using OrderService.Application.DTOs;

namespace OrderService.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetMyOrdersAsync(string userId);
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto?> GetByIdAsync(Guid id);
    Task<OrderDto?> GetByTrackingIdAsync(string trackingId);
    Task<OrderDto> CreateOrderAsync(string userId, CreateOrderDto dto);
    Task<bool> UpdateStatusAsync(Guid id, OrderStatus status);
    Task<bool> CancelOrderAsync(Guid id, string userId);
    Task<byte[]> GenerateInvoiceAsync(Guid id);
}
