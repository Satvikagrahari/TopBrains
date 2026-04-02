using System;
using System.Collections.Generic;
using System.Text;
using CartService.Domain.Entities;
using CartService.Domain.Interfaces;
using CartService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CartService.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly CartDbContext _db;
    public CartRepository(CartDbContext db) => _db = db;

    public async Task<Cart?> GetByUserIdAsync(string userId) =>
        await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);

    public async Task<Cart> CreateAsync(Cart cart)
    {
        _db.Carts.Add(cart);
        await _db.SaveChangesAsync();
        return cart;
    }

    public async Task<Cart> UpdateAsync(Cart cart)
    {
        _db.Carts.Update(cart);
        await _db.SaveChangesAsync();
        return await GetByUserIdAsync(cart.UserId) ?? cart;
    }

    public async Task<bool> ClearCartAsync(string userId)
    {
        var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null) return false;
        cart.Items.Clear();
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveItemAsync(string userId, Guid productId)
    {
        var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null) return false;
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) return false;
        cart.Items.Remove(item);
        await _db.SaveChangesAsync();
        return true;
    }
}
