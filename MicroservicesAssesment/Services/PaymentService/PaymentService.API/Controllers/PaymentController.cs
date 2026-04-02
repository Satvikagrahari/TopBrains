using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;

namespace PaymentService.API.Controllers;

[ApiController]
[Route("api/v1/payments")]
[Authorize]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService) => _paymentService = paymentService;

    private string GetUserId() => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;

    /// <summary>Initiate payment for an order (COD/Card/UPI via Razorpay)</summary>
    [HttpPost("initiate")]
    public async Task<IActionResult> Initiate([FromBody] PaymentRequestDto dto)
    {
        try
        {
            var result = await _paymentService.InitiatePaymentAsync(GetUserId(), dto);
            return Ok(new { success = true, data = result });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Verify Razorpay payment signature after payment</summary>
    [HttpPost("verify/{razorpayOrderId}")]
    public async Task<IActionResult> Verify(string razorpayOrderId, [FromBody] VerifyPaymentDto dto)
    {
        try
        {
            var result = await _paymentService.VerifyPaymentAsync(razorpayOrderId, dto);
            return result
                ? Ok(new { success = true, message = "Payment verified successfully." })
                : BadRequest(new { success = false, message = "Payment verification failed." });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Get payment for an order</summary>
    [HttpGet("order/{orderId:guid}")]
    public async Task<IActionResult> GetByOrder(Guid orderId)
    {
        var payment = await _paymentService.GetByOrderIdAsync(orderId);
        return payment == null ? NotFound() : Ok(new { success = true, data = payment });
    }

    /// <summary>Get my payment history</summary>
    [HttpGet("my")]
    public async Task<IActionResult> GetMyPayments()
    {
        var payments = await _paymentService.GetMyPaymentsAsync(GetUserId());
        return Ok(new { success = true, data = payments });
    }
}