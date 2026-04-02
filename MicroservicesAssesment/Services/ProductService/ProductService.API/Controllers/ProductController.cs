using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;

namespace ProductService.API.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) => _productService = productService;

    /// <summary>Get all products with optional filters</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? category,
        [FromQuery] string? search,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice)
    {
        var products = await _productService.GetAllAsync(category, search, minPrice, maxPrice);
        return Ok(new { success = true, data = products });
    }

    /// <summary>Get product by ID</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        return product == null
            ? NotFound(new { success = false, message = "Product not found." })
            : Ok(new { success = true, data = product });
    }

    /// <summary>Create a new product (Admin or StoreManager)</summary>
    [HttpPost]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        try
        {
            var product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, new { success = true, data = product });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Update a product (Admin or StoreManager)</summary>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
    {
        try
        {
            var product = await _productService.UpdateAsync(id, dto);
            return Ok(new { success = true, data = product });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Delete a product (Admin only)</summary>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _productService.DeleteAsync(id);
        return result ? Ok(new { success = true, message = "Product deleted." }) : NotFound();
    }

    /// <summary>Update stock quantity</summary>
    [HttpPatch("{id:guid}/stock")]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> UpdateStock(Guid id, [FromQuery] int quantity)
    {
        var result = await _productService.UpdateStockAsync(id, quantity);
        return result ? Ok(new { success = true, message = "Stock updated." }) : NotFound();
    }

    /// <summary>Upload product image</summary>
    [HttpPost("{id:guid}/image")]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> UploadImage(Guid id, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest(new { success = false, message = "No file provided." });

        var url = await _productService.UploadImageAsync(id, file.OpenReadStream(), file.FileName);
        return Ok(new { success = true, imageUrl = url });
    }
}