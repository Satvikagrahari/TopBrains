using System;
using System.Collections.Generic;
using System.Text;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(string? category = null, string? search = null, decimal? minPrice = null, decimal? maxPrice = null);
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateStockAsync(Guid id, int quantity);
}
