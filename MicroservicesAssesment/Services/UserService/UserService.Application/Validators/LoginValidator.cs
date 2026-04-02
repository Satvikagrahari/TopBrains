using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UserService.Application.DTOs;

namespace UserService.Application.Validators;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
