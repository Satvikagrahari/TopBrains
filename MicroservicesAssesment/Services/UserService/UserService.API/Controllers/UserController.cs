using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/v1/users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) => _userService = userService;

    private string GetUserId() =>
        User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;

    /// <summary>Get current user profile</summary>
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var profile = await _userService.GetProfileAsync(GetUserId());
        return profile == null
            ? NotFound(new { success = false, message = "User not found." })
            : Ok(new { success = true, data = profile });
    }

    /// <summary>Update current user profile</summary>
    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
    {
        try
        {
            var result = await _userService.UpdateProfileAsync(GetUserId(), dto);
            return Ok(new { success = true, data = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Upload profile image</summary>
    [HttpPost("profile/image")]
    public async Task<IActionResult> UploadProfileImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest(new { success = false, message = "No file uploaded." });

        var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var ext = Path.GetExtension(file.FileName).ToLower();
        if (!allowed.Contains(ext))
            return BadRequest(new { success = false, message = "Invalid file type." });

        var url = await _userService.UploadProfileImageAsync(GetUserId(), file.OpenReadStream(), file.FileName);
        return Ok(new { success = true, imageUrl = url });
    }

    /// <summary>Toggle MFA on/off</summary>
    [HttpPost("mfa/toggle")]
    public async Task<IActionResult> ToggleMfa([FromQuery] bool enable)
    {
        var result = await _userService.ToggleMfaAsync(GetUserId(), enable);
        return Ok(new { success = true, message = $"MFA {(enable ? "enabled" : "disabled")}." });
    }

    // ── Admin Only ────────────────────────────────────────────────────────

    /// <summary>Get all users (Admin only)</summary>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(new { success = true, data = users });
    }

    /// <summary>Soft-delete a user (Admin only)</summary>
    [HttpDelete("{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var result = await _userService.DeleteUserAsync(userId);
        return result
            ? Ok(new { success = true, message = "User deleted." })
            : NotFound(new { success = false, message = "User not found." });
    }
}