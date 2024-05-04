using System.Security.Claims;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("/api/shopping-list")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private readonly IShoppingListService _shoppingListService;
    private readonly UserManager<AppUser> _userManager;

    public ShoppingListController(IShoppingListService shoppingListService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _shoppingListService = shoppingListService;
        _userManager = userManager;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var user = GetSendingUser();
        var shoppingLists = await _shoppingListService.GetAllAsync(user);
        
        return Ok(shoppingLists);
    }



    private AppUser GetSendingUser()
    {
        return new AppUser
        {
            UserName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value
        };
    }
}