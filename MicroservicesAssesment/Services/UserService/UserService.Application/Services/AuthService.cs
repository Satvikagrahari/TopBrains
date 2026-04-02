using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<TokenResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existing = await _userManager.FindByEmailAsync(dto.Email);
        if (existing != null)
            throw new Exception("User with this email already exists.");

        if (dto.Password != dto.ConfirmPassword)
            throw new Exception("Passwords do not match.");

        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

        // Assign role
        var validRoles = new[] { "Admin", "StoreManager", "Customer" };
        var role = validRoles.Contains(dto.Role) ? dto.Role : "Customer";
        await _userManager.AddToRoleAsync(user, role);

        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _tokenService.GenerateAccessToken(user, roles);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new TokenResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),
            UserId = user.Id,
            Email = user.Email!,
            Role = role
        };
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email)
            ?? throw new Exception("Invalid email or password.");

        if (!await _userManager.CheckPasswordAsync(user, dto.Password))
            throw new Exception("Invalid email or password.");

        if (!user.IsActive)
            throw new Exception("Account is deactivated. Contact support.");

        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _tokenService.GenerateAccessToken(user, roles);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new TokenResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),
            UserId = user.Id,
            Email = user.Email!,
            Role = roles.FirstOrDefault() ?? "Customer",
            RequiresMfa = user.IsMfaEnabled
        };
    }

    public async Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenDto dto)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(dto.AccessToken)
            ?? throw new Exception("Invalid access token.");

        var userId = principal.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
            ?? throw new Exception("Invalid token claims.");

        var user = await _userManager.FindByIdAsync(userId)
            ?? throw new Exception("User not found.");

        if (user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
            throw new Exception("Invalid or expired refresh token.");

        var roles = await _userManager.GetRolesAsync(user);
        var newAccessToken = _tokenService.GenerateAccessToken(user, roles);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new TokenResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),
            UserId = user.Id,
            Email = user.Email!,
            Role = roles.FirstOrDefault() ?? "Customer"
        };
    }

    public async Task<bool> RevokeTokenAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;
        user.RefreshToken = null;
        user.RefreshTokenExpiry = null;
        await _userManager.UpdateAsync(user);
        return true;
    }
}
