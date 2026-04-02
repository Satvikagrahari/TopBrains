using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Interfaces;

public interface IWhatsAppService
{
    Task SendAsync(string phoneNumber, string message);
}
