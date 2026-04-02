using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;

namespace CartService.Domain.Entities;

public class Cart : AuditableEntity
{
    public string UserId { get; set; } = string.Empty;
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    public decimal TotalPrice => Items.Sum(i => i.SubTotal);
}
