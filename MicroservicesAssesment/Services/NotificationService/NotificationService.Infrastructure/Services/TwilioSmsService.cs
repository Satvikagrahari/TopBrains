using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using NotificationService.Application.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NotificationService.Infrastructure.Services;

public class TwilioSmsService : ISmsService
{
    private readonly IConfiguration _config;
    public TwilioSmsService(IConfiguration config) => _config = config;

    public async Task SendAsync(string phoneNumber, string message)
    {
        TwilioClient.Init(_config["Twilio:AccountSid"], _config["Twilio:AuthToken"]);
        await MessageResource.CreateAsync(
            from: new PhoneNumber(_config["Twilio:SmsFrom"]),
            to: new PhoneNumber(phoneNumber),
            body: message
        );
    }
}
