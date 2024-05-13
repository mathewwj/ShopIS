using System.Security.Claims;
using api.Models;

namespace api.Services;

public interface IAuthService
{
    public Task<bool> IsValidRole(AppUser? user, UserRole role);
    public Task<bool> IsValidRole(ClaimsPrincipal user, UserRole role);
    public Task<AppUser?> GetAppUser(ClaimsPrincipal user);
}