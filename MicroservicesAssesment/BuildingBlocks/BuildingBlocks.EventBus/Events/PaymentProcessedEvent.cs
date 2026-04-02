using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.Events;

public class PaymentProcessedEvent
{
    public Guid PaymentId { get; set; }
    public Guid OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public decimal Amount { get; set; }
}
