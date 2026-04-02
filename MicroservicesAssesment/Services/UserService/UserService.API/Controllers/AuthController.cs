using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IOtpService _otpService;

    public AuthController(IAuthService authService, IOtpService otpService)
    {
        _authService = authService;
        _otpService = otpService;
    }

    /// <summary>Register a new user (Customer/StoreManager/Admin)</summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(new { success = true, data = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Login and receive JWT tokens</summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(new { success = true, data = result });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Refresh expired access token using refresh token</summary>
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
    {
        try
        {
            var result = await _authService.RefreshTokenAsync(dto);
            return Ok(new { success = true, data = result });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Revoke refresh token (Logout)</summary>
    [Authorize]
    [HttpPost("revoke")]
    public async Task<IActionResult> Revoke()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
        await _authService.RevokeTokenAsync(userId);
        return Ok(new { success = true, message = "Token revoked successfully." });
    }

    /// <summary>Send OTP via Email/SMS/WhatsApp</summary>
    [Authorize]
    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp([FromBody] SendOtpDto dto)
    {
        try
        {
            var otp = await _otpService.GenerateAndSendOtpAsync(dto.UserId, dto.Channel, dto.Purpose);
            return Ok(new { success = true, message = $"OTP sent via {dto.Channel}.", otp }); // remove otp in production
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /// <summary>Verify OTP</summary>
    [Authorize]
    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
    {
        var isValid = await _otpService.VerifyOtpAsync(dto.UserId, dto.OtpCode, dto.Purpose);
        return isValid
            ? Ok(new { success = true, message = "OTP verified successfully." })
            : BadRequest(new { success = false, message = "Invalid or expired OTP." });
    }
}