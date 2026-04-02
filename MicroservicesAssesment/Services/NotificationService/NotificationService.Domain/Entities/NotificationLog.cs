using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.SharedKernel;

namespace NotificationService.Domain.Entities;

public class NotificationLog : AuditableEntity
{
    public string Channel { get; set; } = string.Empty; // Email, SMS, WhatsApp
    public string Recipient { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
}
