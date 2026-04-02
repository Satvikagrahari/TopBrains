using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Services;

public class UserAppService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserAppService(UserManager<ApplicationUser> userManager) => _userManager = userManager;

    public async Task<UserProfileDto?> GetProfileAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return null;

        var roles = await _userManager.GetRolesAsync(user);
        return MapToDto(user, roles.FirstOrDefault() ?? "Customer");
    }

    public async Task<UserProfileDto> UpdateProfileAsync(string userId, UpdateProfileDto dto)
    {
        var user = await _userManager.FindByIdAsync(userId)
            ?? throw new Exception("User not found.");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.UpdatedAt = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        return MapToDto(user, roles.FirstOrDefault() ?? "Customer");
    }

    public async Task<string> UploadProfileImageAsync(string userId, Stream imageStream, string fileName)
    {
        var user = await _userManager.FindByIdAsync(userId)
            ?? throw new Exception("User not found.");

        // Save image to wwwroot/uploads
        var uploadsDir = Path.Combine("wwwroot", "uploads", "profiles");
        Directory.CreateDirectory(uploadsDir);

        var ext = Path.GetExtension(fileName);
        var newFileName = $"{userId}{ext}";
        var filePath = Path.Combine(uploadsDir, newFileName);

        using var fs = new FileStream(filePath, FileMode.Create);
        await imageStream.CopyToAsync(fs);

        var imageUrl = $"/uploads/profiles/{newFileName}";
        user.ProfileImageUrl = imageUrl;
        await _userManager.UpdateAsync(user);

        return imageUrl;
    }

    public async Task<IEnumerable<UserProfileDto>> GetAllUsersAsync()
    {
        var users = _userManager.Users.Where(u => u.IsActive).ToList();
        var result = new List<UserProfileDto>();
        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            result.Add(MapToDto(user, roles.FirstOrDefault() ?? "Customer"));
        }
        return result;
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;
        user.IsActive = false;
        await _userManager.UpdateAsync(user);
        return true;
    }

    public async Task<bool> ToggleMfaAsync(string userId, bool enable)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;
        user.IsMfaEnabled = enable;
        await _userManager.UpdateAsync(user);
        return true;
    }

    private static UserProfileDto MapToDto(ApplicationUser user, string role) => new()
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email!,
        PhoneNumber = user.PhoneNumber,
        ProfileImageUrl = user.ProfileImageUrl,
        Role = role,
        IsMfaEnabled = user.IsMfaEnabled,
        CreatedAt = user.CreatedAt
    };
}