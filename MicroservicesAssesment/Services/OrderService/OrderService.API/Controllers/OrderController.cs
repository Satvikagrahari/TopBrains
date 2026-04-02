using BuildingBlocks.SharedKernel.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;

namespace OrderService.API.Controllers;

[ApiController]
[Route("api/v1/orders")]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService) => _orderService = orderService;

    private string GetUserId() => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;

    /// <summary>Get my orders (Customer)</summary>
    [HttpGet("my")]
    public async Task<IActionResult> GetMyOrders()
    {
        var orders = await _orderService.GetMyOrdersAsync(GetUserId());
        return Ok(new { success = true, data = orders });
    }

    /// <summary>Get all orders (Admin/StoreManager)</summary>
    [HttpGet]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(new { success = true, data = orders });
    }

    /// <summary>Get order by ID</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(new { success = true, data = order });
    }

    /// <summary>Track order by tracking ID</summary>
    [HttpGet("track/{trackingId}")]
    [AllowAnonymous]
    public async Task<IActionResult> Track(string trackingId)
    {
        var order = await _orderService.GetByTrackingIdAsync(trackingId);
        return order == null
            ? NotFound(new { success = false, message = "Tracking ID not found." })
            : Ok(new { success = true, data = new { order.TrackingId, order.Status, order.StatusDisplay, order.CreatedAt } });
    }

    /// <summary>Create a new order</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
    {
        try
        {
            var order = await _orderService.CreateOrderAsync(GetUserId(), dto);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, new { success = true, data = order });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Update order status (Admin/StoreManager)</summary>
    [HttpPatch("{id:guid}/status")]
    [Authorize(Roles = "Admin,StoreManager")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] OrderStatus status)
    {
        var result = await _orderService.UpdateStatusAsync(id, status);
        return result ? Ok(new { success = true, message = "Status updated." }) : NotFound();
    }

    /// <summary>Cancel my order</summary>
    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        try
        {
            var result = await _orderService.CancelOrderAsync(id, GetUserId());
            return result ? Ok(new { success = true, message = "Order cancelled." }) : NotFound();
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Download invoice PDF</summary>
    [HttpGet("{id:guid}/invoice")]
    public async Task<IActionResult> DownloadInvoice(Guid id)
    {
        try
        {
            var pdf = await _orderService.GenerateInvoiceAsync(id);
            return File(pdf, "application/pdf", $"invoice-{id}.pdf");
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }
}