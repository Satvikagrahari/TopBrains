using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;

namespace ProductService.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public string SKU { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
