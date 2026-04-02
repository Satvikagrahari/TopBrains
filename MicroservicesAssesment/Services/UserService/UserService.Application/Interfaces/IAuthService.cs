using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;

namespace UserService.Application.Interfaces;

public interface IAuthService
{
    Task<TokenResponseDto> RegisterAsync(RegisterDto dto);
    Task<TokenResponseDto> LoginAsync(LoginDto dto);
    Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenDto dto);
    Task<bool> RevokeTokenAsync(string userId);
}
