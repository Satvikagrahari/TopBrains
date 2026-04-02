using CartService.Application.DTOs;
using CartService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CartService.API.Controllers;

[ApiController]
[Route("api/v1/cart")]
[Authorize]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    public CartController(ICartService cartService) => _cartService = cartService;

    private string GetUserId() => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;

    /// <summary>Get current user's cart</summary>
    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var cart = await _cartService.GetCartAsync(GetUserId());
        return Ok(new { success = true, data = cart ?? new CartDto { UserId = GetUserId(), Items = new() } });
    }

    /// <summary>Add item to cart</summary>
    [HttpPost("items")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
    {
        try
        {
            var cart = await _cartService.AddToCartAsync(GetUserId(), dto);
            return Ok(new { success = true, data = cart });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Update item quantity</summary>
    [HttpPut("items")]
    public async Task<IActionResult> UpdateItem([FromBody] UpdateCartItemDto dto)
    {
        try
        {
            var cart = await _cartService.UpdateItemQuantityAsync(GetUserId(), dto);
            return Ok(new { success = true, data = cart });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Remove item from cart</summary>
    [HttpDelete("items/{productId:guid}")]
    public async Task<IActionResult> RemoveItem(Guid productId)
    {
        var result = await _cartService.RemoveItemAsync(GetUserId(), productId);
        return result ? Ok(new { success = true, message = "Item removed." }) : NotFound();
    }

    /// <summary>Clear all items from cart</summary>
    [HttpDelete]
    public async Task<IActionResult> ClearCart()
    {
        await _cartService.ClearCartAsync(GetUserId());
        return Ok(new { success = true, message = "Cart cleared." });
    }
}