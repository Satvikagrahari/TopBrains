using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Services;

public class CategoryAppService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo;
    private readonly IMapper _mapper;

    public CategoryAppService(ICategoryRepository categoryRepo, IMapper mapper)
    {
        _categoryRepo = categoryRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var cats = await _categoryRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(cats);
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid id)
    {
        var cat = await _categoryRepo.GetByIdAsync(id);
        return cat == null ? null : _mapper.Map<CategoryDto>(cat);
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var cat = _mapper.Map<Category>(dto);
        var created = await _categoryRepo.CreateAsync(cat);
        return _mapper.Map<CategoryDto>(created);
    }

    public async Task<CategoryDto> UpdateAsync(Guid id, CreateCategoryDto dto)
    {
        var existing = await _categoryRepo.GetByIdAsync(id)
            ?? throw new Exception("Category not found.");
        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.UpdatedAt = DateTime.UtcNow;
        var updated = await _categoryRepo.UpdateAsync(existing);
        return _mapper.Map<CategoryDto>(updated);
    }

    public async Task<bool> DeleteAsync(Guid id) => await _categoryRepo.DeleteAsync(id);
}
