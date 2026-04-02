using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel.Enums;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _db;
    public OrderRepository(OrderDbContext db) => _db = db;

    public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId) =>
        await _db.Orders.Include(o => o.Items).Where(o => o.UserId == userId).OrderByDescending(o => o.CreatedAt).ToListAsync();

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await _db.Orders.Include(o => o.Items).OrderByDescending(o => o.CreatedAt).ToListAsync();

    public async Task<Order?> GetByIdAsync(Guid id) =>
        await _db.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order?> GetByTrackingIdAsync(string trackingId) =>
        await _db.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.TrackingId == trackingId);

    public async Task<Order> CreateAsync(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return await GetByIdAsync(order.Id) ?? order;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _db.Orders.Update(order);
        await _db.SaveChangesAsync();
        return order;
    }

    public async Task<bool> UpdateStatusAsync(Guid id, OrderStatus status)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order == null) return false;
        order.Status = status;
        order.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return true;
    }
}
