using System;
using System.Collections.Generic;
using System.Text;
using CartService.Domain.Entities;

namespace CartService.Domain.Interfaces;

public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(string userId);
    Task<Cart> CreateAsync(Cart cart);
    Task<Cart> UpdateAsync(Cart cart);
    Task<bool> ClearCartAsync(string userId);
    Task<bool> RemoveItemAsync(string userId, Guid productId);
}
