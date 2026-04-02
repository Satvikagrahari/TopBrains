using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductDbContext _db;
    public CategoryRepository(ProductDbContext db) => _db = db;

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _db.Categories.Include(c => c.Products).Where(c => c.IsActive).ToListAsync();

    public async Task<Category?> GetByIdAsync(Guid id) =>
        await _db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Category> CreateAsync(Category category)
    {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _db.Categories.Update(category);
        await _db.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var cat = await _db.Categories.FindAsync(id);
        if (cat == null) return false;
        cat.IsActive = false;
        await _db.SaveChangesAsync();
        return true;
    }
}
