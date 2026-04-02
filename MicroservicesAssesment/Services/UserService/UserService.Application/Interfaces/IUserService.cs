using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;

namespace UserService.Application.Interfaces;

public interface IUserService
{
    Task<UserProfileDto?> GetProfileAsync(string userId);
    Task<UserProfileDto> UpdateProfileAsync(string userId, UpdateProfileDto dto);
    Task<string> UploadProfileImageAsync(string userId, Stream imageStream, string fileName);
    Task<IEnumerable<UserProfileDto>> GetAllUsersAsync();
    Task<bool> DeleteUserAsync(string userId);
    Task<bool> ToggleMfaAsync(string userId, bool enable);
}
