using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;

namespace ProductService.Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
