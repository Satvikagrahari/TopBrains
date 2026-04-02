using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Services;

public class ProductAppService : IProductService
{
    private readonly IProductRepository _productRepo;
    private readonly IMapper _mapper;

    public ProductAppService(IProductRepository productRepo, IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(string? category = null, string? search = null, decimal? minPrice = null, decimal? maxPrice = null)
    {
        var products = await _productRepo.GetAllAsync(category, search, minPrice, maxPrice);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        return product == null ? null : _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        product.SKU = string.IsNullOrEmpty(product.SKU) ? $"SKU-{Guid.NewGuid().ToString()[..8].ToUpper()}" : product.SKU;
        var created = await _productRepo.CreateAsync(product);
        return _mapper.Map<ProductDto>(created);
    }

    public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto dto)
    {
        var existing = await _productRepo.GetByIdAsync(id)
            ?? throw new Exception("Product not found.");
        _mapper.Map(dto, existing);
        existing.UpdatedAt = DateTime.UtcNow;
        var updated = await _productRepo.UpdateAsync(existing);
        return _mapper.Map<ProductDto>(updated);
    }

    public async Task<bool> DeleteAsync(Guid id) => await _productRepo.DeleteAsync(id);

    public async Task<bool> UpdateStockAsync(Guid id, int quantity) =>
        await _productRepo.UpdateStockAsync(id, quantity);

    public async Task<string> UploadImageAsync(Guid id, Stream imageStream, string fileName)
    {
        var product = await _productRepo.GetByIdAsync(id)
            ?? throw new Exception("Product not found.");

        var uploadsDir = Path.Combine("wwwroot", "uploads", "products");
        Directory.CreateDirectory(uploadsDir);
        var ext = Path.GetExtension(fileName);
        var newFileName = $"{id}{ext}";
        var filePath = Path.Combine(uploadsDir, newFileName);

        using var fs = new FileStream(filePath, FileMode.Create);
        await imageStream.CopyToAsync(fs);

        var imageUrl = $"/uploads/products/{newFileName}";
        product.ImageUrl = imageUrl;
        product.UpdatedAt = DateTime.UtcNow;
        await _productRepo.UpdateAsync(product);
        return imageUrl;
    }
}
