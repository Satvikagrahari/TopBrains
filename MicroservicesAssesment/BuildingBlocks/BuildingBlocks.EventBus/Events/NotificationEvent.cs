using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.Events;

public class NotificationEvent
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Type { get; set; } = "Email"; // Email, SMS, WhatsApp
}
