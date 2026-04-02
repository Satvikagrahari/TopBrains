using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.DTOs;
using NotificationService.Application.Interfaces;

namespace NotificationService.API.Controllers;

[ApiController]
[Route("api/v1/notifications")]
[Authorize]
public class NotificationController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;
    private readonly IWhatsAppService _whatsAppService;

    public NotificationController(IEmailService emailService, ISmsService smsService, IWhatsAppService whatsAppService)
    {
        _emailService = emailService;
        _smsService = smsService;
        _whatsAppService = whatsAppService;
    }

    /// <summary>Send Email notification</summary>
    [HttpPost("send-email")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SendEmail([FromBody] EmailNotificationDto dto)
    {
        try
        {
            await _emailService.SendAsync(dto.To, dto.Subject, dto.Body);
            return Ok(new { success = true, message = "Email sent." });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Send SMS notification</summary>
    [HttpPost("send-sms")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SendSms([FromBody] SmsNotificationDto dto)
    {
        try
        {
            await _smsService.SendAsync(dto.PhoneNumber, dto.Message);
            return Ok(new { success = true, message = "SMS sent." });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }

    /// <summary>Send WhatsApp notification</summary>
    [HttpPost("send-whatsapp")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SendWhatsApp([FromBody] WhatsAppNotificationDto dto)
    {
        try
        {
            await _whatsAppService.SendAsync(dto.PhoneNumber, dto.Message);
            return Ok(new { success = true, message = "WhatsApp message sent." });
        }
        catch (Exception ex) { return BadRequest(new { success = false, message = ex.Message }); }
    }
}