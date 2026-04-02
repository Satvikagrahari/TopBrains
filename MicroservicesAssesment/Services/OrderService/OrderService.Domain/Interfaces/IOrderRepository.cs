using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel.Enums;
using OrderService.Domain.Entities;

namespace OrderService.Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetByUserIdAsync(string userId);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order?> GetByTrackingIdAsync(string trackingId);
    Task<Order> CreateAsync(Order order);
    Task<Order> UpdateAsync(Order order);
    Task<bool> UpdateStatusAsync(Guid id, OrderStatus status);
}
