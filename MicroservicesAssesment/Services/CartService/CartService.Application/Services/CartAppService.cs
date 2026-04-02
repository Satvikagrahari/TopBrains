using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CartService.Application.DTOs;
using CartService.Application.Interfaces;
using CartService.Domain.Entities;
using CartService.Domain.Interfaces;

namespace CartService.Application.Services;

public class CartAppService : ICartService
{
    private readonly ICartRepository _cartRepo;
    private readonly IMapper _mapper;

    public CartAppService(ICartRepository cartRepo, IMapper mapper)
    {
        _cartRepo = cartRepo;
        _mapper = mapper;
    }

    public async Task<CartDto?> GetCartAsync(string userId)
    {
        var cart = await _cartRepo.GetByUserIdAsync(userId);
        return cart == null ? null : _mapper.Map<CartDto>(cart);
    }

    public async Task<CartDto> AddToCartAsync(string userId, AddToCartDto dto)
    {
        var cart = await _cartRepo.GetByUserIdAsync(userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            cart.Items.Add(new CartItem
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                UnitPrice = dto.UnitPrice,
                Quantity = dto.Quantity,
                ImageUrl = dto.ImageUrl
            });
            cart = await _cartRepo.CreateAsync(cart);
        }
        else
        {
            var existing = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
            if (existing != null)
                existing.Quantity += dto.Quantity;
            else
                cart.Items.Add(new CartItem
                {
                    CartId = cart.Id,
                    ProductId = dto.ProductId,
                    ProductName = dto.ProductName,
                    UnitPrice = dto.UnitPrice,
                    Quantity = dto.Quantity,
                    ImageUrl = dto.ImageUrl
                });
            cart = await _cartRepo.UpdateAsync(cart);
        }

        return _mapper.Map<CartDto>(cart);
    }

    public async Task<CartDto> UpdateItemQuantityAsync(string userId, UpdateCartItemDto dto)
    {
        var cart = await _cartRepo.GetByUserIdAsync(userId)
            ?? throw new Exception("Cart not found.");

        var item = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId)
            ?? throw new Exception("Item not in cart.");

        if (dto.Quantity <= 0)
            cart.Items.Remove(item);
        else
            item.Quantity = dto.Quantity;

        cart = await _cartRepo.UpdateAsync(cart);
        return _mapper.Map<CartDto>(cart);
    }

    public async Task<bool> RemoveItemAsync(string userId, Guid productId) =>
        await _cartRepo.RemoveItemAsync(userId, productId);

    public async Task<bool> ClearCartAsync(string userId) =>
        await _cartRepo.ClearCartAsync(userId);
}
