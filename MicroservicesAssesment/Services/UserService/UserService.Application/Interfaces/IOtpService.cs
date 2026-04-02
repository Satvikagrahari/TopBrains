using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces;

public interface IOtpService
{
    Task<string> GenerateAndSendOtpAsync(string userId, string channel, string purpose);
    Task<bool> VerifyOtpAsync(string userId, string otpCode, string purpose);
}
