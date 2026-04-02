using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UserService.Application.Interfaces;

namespace UserService.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config) => _config = config;

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var smtp = _config.GetSection("SmtpSettings");

        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(smtp["FromEmail"]));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart("html") { Text = body };

        using var client = new SmtpClient();
        await client.ConnectAsync(smtp["Host"], int.Parse(smtp["Port"]!), SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(smtp["Username"], smtp["Password"]);
        await client.SendAsync(email);
        await client.DisconnectAsync(true);
    }

    public async Task SendOtpEmailAsync(string to, string otp, string purpose)
    {
        var body = $"""
            <h2>E-Commerce Platform</h2>
            <p>Your OTP for <strong>{purpose}</strong> is:</p>
            <h1 style='color:#2563eb;letter-spacing:8px;'>{otp}</h1>
            <p>This OTP is valid for <strong>10 minutes</strong>.</p>
            <p>If you did not request this, please ignore this email.</p>
        """;

        await SendEmailAsync(to, $"Your OTP - {purpose}", body);
    }
}
