using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NotificationService.Application.Interfaces;

namespace NotificationService.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    public EmailService(IConfiguration config) => _config = config;

    public async Task SendAsync(string to, string subject, string body)
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
}
