using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;
using BuildingBlocks.SharedKernel.Enums;

namespace PaymentService.Domain.Entities;

public class Payment : AuditableEntity
{
    public Guid OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "INR";
    public string Method { get; set; } = string.Empty; // Card, UPI, COD
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? RazorpayOrderId { get; set; }
    public string? RazorpayPaymentId { get; set; }
    public string? RazorpaySignature { get; set; }
    public string? FailureReason { get; set; }
    public DateTime? PaidAt { get; set; }
}
