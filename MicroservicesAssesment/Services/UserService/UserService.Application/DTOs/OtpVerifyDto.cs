using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs;

public class SendOtpDto
{
    public string UserId { get; set; } = string.Empty;
    public string Channel { get; set; } = "Email"; // Email, SMS, WhatsApp
    public string Purpose { get; set; } = "MFA";
}

public class VerifyOtpDto
{
    public string UserId { get; set; } = string.Empty;
    public string OtpCode { get; set; } = string.Empty;
    public string Purpose { get; set; } = "MFA";
}

public class RefreshTokenDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
