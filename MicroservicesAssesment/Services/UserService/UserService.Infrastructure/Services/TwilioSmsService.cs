using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using UserService.Application.Interfaces;

namespace UserService.Infrastructure.Services;

public class TwilioSmsService : ISmsService
{
    private readonly IConfiguration _config;

    public TwilioSmsService(IConfiguration config) => _config = config;

    public async Task SendOtpAsync(string phoneNumber, string otp, string channel = "SMS")
    {
        var message = $"Your OTP is: {otp}. Valid for 10 minutes. Do not share it with anyone.";
        await SendMessageAsync(phoneNumber, message, channel);
    }

    public async Task SendMessageAsync(string phoneNumber, string message, string channel = "SMS")
    {
        var accountSid = _config["Twilio:AccountSid"];
        var authToken = _config["Twilio:AuthToken"];
        TwilioClient.Init(accountSid, authToken);

        PhoneNumber from;
        PhoneNumber to;

        if (channel == "WhatsApp")
        {
            from = new PhoneNumber($"whatsapp:{_config["Twilio:WhatsAppFrom"]}");
            to = new PhoneNumber($"whatsapp:{phoneNumber}");
        }
        else
        {
            from = new PhoneNumber(_config["Twilio:SmsFrom"]);
            to = new PhoneNumber(phoneNumber);
        }

        await MessageResource.CreateAsync(from: from, to: to, body: message);
    }
}
