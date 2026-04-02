using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(ApplicationUser user, IList<string> roles);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
