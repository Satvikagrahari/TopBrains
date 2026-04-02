using System;
using System.Collections.Generic;
using System.Text;
using CartService.Application.DTOs;

namespace CartService.Application.Interfaces;

public interface ICartService
{
    Task<CartDto?> GetCartAsync(string userId);
    Task<CartDto> AddToCartAsync(string userId, AddToCartDto dto);
    Task<CartDto> UpdateItemQuantityAsync(string userId, UpdateCartItemDto dto);
    Task<bool> RemoveItemAsync(string userId, Guid productId);
    Task<bool> ClearCartAsync(string userId);
}
