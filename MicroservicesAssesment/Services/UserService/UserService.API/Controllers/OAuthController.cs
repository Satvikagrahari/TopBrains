using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/v1/oauth")]
public class OAuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public OAuthController(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    /// <summary>Initiate Google OAuth login — open this in browser</summary>
    [HttpGet("google")]
    [AllowAnonymous]
    public IActionResult GoogleLogin()
    {
        var redirectUrl = Url.Action(
            nameof(GoogleCallback),
            "OAuth",
            null,
            "http",
            "localhost:5010"
        );

        var properties = new AuthenticationProperties
        {
            RedirectUri = redirectUrl,
            Items =
            {
                { "scheme", GoogleDefaults.AuthenticationScheme }
            }
        };

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    /// <summary>Google OAuth callback</summary>
    [HttpGet("google/callback")]
    [AllowAnonymous]
    public async Task<IActionResult> GoogleCallback()
    {
        try
        {
            // Authenticate using cookie scheme
            var result = await HttpContext.AuthenticateAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
                return BadRequest(new
                {
                    success = false,
                    message = "Google authentication failed.",
                    error = result.Failure?.Message
                });

            var email = result.Principal?
                .FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var firstName = result.Principal?
                .FindFirst(System.Security.Claims.ClaimTypes.GivenName)?.Value ?? "";
            var lastName = result.Principal?
                .FindFirst(System.Security.Claims.ClaimTypes.Surname)?.Value ?? "";

            if (string.IsNullOrEmpty(email))
                return BadRequest(new
                {
                    success = false,
                    message = "Could not get email from Google."
                });

            // Find or create user
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailConfirmed = true,
                    IsActive = true
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                    return BadRequest(new
                    {
                        success = false,
                        message = string.Join(", ",
                            createResult.Errors.Select(e => e.Description))
                    });

                await _userManager.AddToRoleAsync(user, "Customer");
            }

            // Generate JWT tokens
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _tokenService.GenerateAccessToken(user, roles);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            // Sign out of cookie session
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok(new
            {
                success = true,
                data = new
                {
                    accessToken,
                    refreshToken,
                    userId = user.Id,
                    email = user.Email,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    role = roles.FirstOrDefault() ?? "Customer"
                }
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
}