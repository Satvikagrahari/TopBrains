using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
    Task SendOtpEmailAsync(string to, string otp, string purpose);
}
