using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Interfaces;

public interface ISmsService
{
    Task SendAsync(string phoneNumber, string message);
}
