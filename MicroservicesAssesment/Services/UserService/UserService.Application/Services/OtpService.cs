using Microsoft.AspNetCore.Identity;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Services;

public class OtpService : IOtpService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;
    private readonly OtpStore _otpStore;  // ← injected singleton

    public OtpService(
        UserManager<ApplicationUser> userManager,
        IEmailService emailService,
        ISmsService smsService,
        OtpStore otpStore)  // ← added
    {
        _userManager = userManager;
        _emailService = emailService;
        _smsService = smsService;
        _otpStore = otpStore;
    }

    public async Task<string> GenerateAndSendOtpAsync(string userId, string channel, string purpose)
    {
        var user = await _userManager.FindByIdAsync(userId)
            ?? throw new Exception("User not found.");

        var otpCode = new Random().Next(100000, 999999).ToString();

        var record = new OtpRecord
        {
            UserId = userId,
            OtpCode = otpCode,
            Purpose = purpose,
            Channel = channel,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10)
        };

        // Remove old OTPs for same user/purpose
        _otpStore.RemoveAll(o => o.UserId == userId && o.Purpose == purpose);
        _otpStore.Add(record);

        if (channel == "Email")
            await _emailService.SendOtpEmailAsync(user.Email!, otpCode, purpose);
        else if (channel is "SMS" or "WhatsApp")
            await _smsService.SendOtpAsync(user.PhoneNumber!, otpCode, channel);

        return otpCode;
    }

    public Task<bool> VerifyOtpAsync(string userId, string otpCode, string purpose)
    {
        var record = _otpStore.Find(userId, otpCode, purpose);

        if (record == null) return Task.FromResult(false);

        record.IsUsed = true;
        return Task.FromResult(true);
    }
}