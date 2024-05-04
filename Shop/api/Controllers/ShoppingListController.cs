using System.Security.Claims;
using api.Mappers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
        if (user == null)
        {
            return BadRequest("user not found");
        }
        var shoppingLists = await _shoppingListService.GetAllAsync(user);
        
        return Ok(shoppingLists.Select(sl => sl.ToShoppingListDto()));
    }
    
    [HttpPost]
    [Authorize]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = GetSendingUser();
        if (user == null)
        {
            return BadRequest("user not found");
        }
        var shoppingList = await _shoppingListService.GetByIdAsync(user, id);
        if (shoppingList == null)
        {
            return NotFound();
        }
        
        return Ok(shoppingList.ToShoppingListDto());
    }



    private AppUser? GetSendingUser()
    {
        var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        return _userManager.Users.FirstOrDefault(u => u.Email == username);
    }
}