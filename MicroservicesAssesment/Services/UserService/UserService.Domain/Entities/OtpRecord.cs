using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities;

public class OtpRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string OtpCode { get; set; } = string.Empty;
    public string Purpose { get; set; } = string.Empty; // EmailVerification, MFA, PasswordReset
    public string Channel { get; set; } = string.Empty; // Email, SMS, WhatsApp
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
