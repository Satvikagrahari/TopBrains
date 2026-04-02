using System;
using System.Collections.Generic;
using System.Text;
namespace PaymentService.Application.DTOs;

public class PaymentRequestDto
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = "COD"; // COD, Card, UPI
    public string Currency { get; set; } = "INR";
}

public class PaymentResponseDto
{
    public Guid PaymentId { get; set; }
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? RazorpayOrderId { get; set; }
    public string? KeyId { get; set; } // For Razorpay frontend integration
    public DateTime CreatedAt { get; set; }
}

public class VerifyPaymentDto
{
    public string RazorpayOrderId { get; set; } = string.Empty;
    public string RazorpayPaymentId { get; set; } = string.Empty;
    public string RazorpaySignature { get; set; } = string.Empty;
}