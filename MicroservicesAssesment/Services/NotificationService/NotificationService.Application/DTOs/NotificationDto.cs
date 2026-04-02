using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.DTOs;

public class EmailNotificationDto
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}

public class SmsNotificationDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

public class WhatsAppNotificationDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
