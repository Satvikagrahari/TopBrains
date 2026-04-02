using System;
using System.Collections.Generic;
using System.Text;
using ProductService.Application.DTOs;

namespace ProductService.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(Guid id);
    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
    Task<CategoryDto> UpdateAsync(Guid id, CreateCategoryDto dto);
    Task<bool> DeleteAsync(Guid id);
}
