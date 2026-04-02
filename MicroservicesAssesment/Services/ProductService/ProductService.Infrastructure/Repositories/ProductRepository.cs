using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _db;

    public ProductRepository(ProductDbContext db) => _db = db;

    public async Task<IEnumerable<Product>> GetAllAsync(string? category = null, string? search = null, decimal? minPrice = null, decimal? maxPrice = null)
    {
        var query = _db.Products.Include(p => p.Category).Where(p => p.IsActive).AsQueryable();

        if (!string.IsNullOrEmpty(category))
            query = query.Where(p => p.Category.Name.ToLower().Contains(category.ToLower()));

        if (!string.IsNullOrEmpty(search))
            query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
                                     p.Description.ToLower().Contains(search.ToLower()));

        if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice.Value);
        if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice.Value);

        return await query.OrderByDescending(p => p.CreatedAt).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product> CreateAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return await GetByIdAsync(product.Id) ?? product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync();
        return await GetByIdAsync(product.Id) ?? product;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return false;
        product.IsActive = false;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateStockAsync(Guid id, int quantity)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return false;
        product.StockQuantity += quantity;
        await _db.SaveChangesAsync();
        return true;
    }
}
