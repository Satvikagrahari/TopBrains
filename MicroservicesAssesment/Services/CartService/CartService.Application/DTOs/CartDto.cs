using System;
using System.Collections.Generic;
using System.Text;
namespace CartService.Application.DTOs;

public class CartDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public List<CartItemDto> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
}

public class CartItemDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public decimal SubTotal { get; set; }
}

public class AddToCartDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; } = 1;
    public string? ImageUrl { get; set; }
}

public class UpdateCartItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
