using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces;

public interface ISmsService
{
    Task SendOtpAsync(string phoneNumber, string otp, string channel = "SMS");
    Task SendMessageAsync(string phoneNumber, string message, string channel = "SMS");
}
