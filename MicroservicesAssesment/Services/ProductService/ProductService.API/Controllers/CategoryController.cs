using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;

namespace ProductService.API.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(new { success = true, data = await _categoryService.GetAllAsync() });

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var cat = await _categoryService.GetByIdAsync(id);
        return cat == null ? NotFound() : Ok(new { success = true, data = cat });
    }

    [HttpPost]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {
        var cat = await _categoryService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = cat.Id }, new { success = true, data = cat });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateCategoryDto dto)
    {
        try
        {
            var cat = await _categoryService.UpdateAsync(id, dto);
            return Ok(new { success = true, data = cat });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return result ? Ok(new { success = true, message = "Category deleted." }) : NotFound();
    }
}