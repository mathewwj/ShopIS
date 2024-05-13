using System.Security.Claims;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Impl;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> IsValidRole(AppUser? user, UserRole role)
    {
        if (user == null)
        {
            return true;
        }

        var roles = await _userManager.GetRolesAsync(user);

        return roles.Contains(role.ToString());
    }

    public async Task<bool> IsValidRole(ClaimsPrincipal user, UserRole role)
    {
        return await IsValidRole(await GetAppUser(user), role);
    }

    public async Task<AppUser?> GetAppUser(ClaimsPrincipal user)
    {
        var username = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == username);
    }
}