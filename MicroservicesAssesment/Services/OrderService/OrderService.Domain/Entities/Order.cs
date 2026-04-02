using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;
using BuildingBlocks.SharedKernel.Enums;

namespace OrderService.Domain.Entities;

public class Order : AuditableEntity
{
    public string UserId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;

    // Billing Address
    public string BillingAddress { get; set; } = string.Empty;
    public string BillingCity { get; set; } = string.Empty;
    public string BillingState { get; set; } = string.Empty;
    public string BillingPinCode { get; set; } = string.Empty;

    public string TrackingId { get; set; } = $"TRK-{Guid.NewGuid().ToString()[..8].ToUpper()}";
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    public string? InvoiceUrl { get; set; }
    public string? PaymentId { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
