using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.Events;

public class OrderCreatedEvent
{
    public Guid OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
