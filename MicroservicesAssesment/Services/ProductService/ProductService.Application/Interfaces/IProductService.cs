using System;
using System.Collections.Generic;
using System.Text;
using ProductService.Application.DTOs;

namespace ProductService.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync(string? category = null, string? search = null, decimal? minPrice = null, decimal? maxPrice = null);
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateStockAsync(Guid id, int quantity);
    Task<string> UploadImageAsync(Guid id, Stream imageStream, string fileName);
}
