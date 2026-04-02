using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UserService.Application.DTOs;

namespace UserService.Application.Validators;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
            .Matches(@"[A-Z]").WithMessage("Must have uppercase.")
            .Matches(@"[0-9]").WithMessage("Must have digit.");
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords must match.");
        RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+?[1-9]\d{9,14}$").WithMessage("Invalid phone number.");
    }
}
