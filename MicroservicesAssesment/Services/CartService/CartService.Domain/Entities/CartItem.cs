using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;

namespace CartService.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public decimal SubTotal => UnitPrice * Quantity;
}
