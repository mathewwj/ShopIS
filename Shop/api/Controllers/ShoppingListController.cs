using System.Security.Claims;
using api.Dto.ShoppingList;
using api.Mappers;
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
        if (user == null)
        {
            return BadRequest("user not found");
        }
        var shoppingLists = await _shoppingListService.GetAllAsync(user);
        
        return Ok(shoppingLists.Select(sl => sl.ToShoppingListDto()));
    }
    
    [HttpGet]
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShoppingListDto shoppingListDto)
    {
        var user = GetSendingUser();
        if (user == null)
        {
            return BadRequest("user not found");
        }
        
        var newShoppingList = shoppingListDto.ToShoppingListFromCreateDto();
        var inMemoryList = await _shoppingListService.CreateAsync(user, newShoppingList);
        return CreatedAtAction(nameof(GetById), new { id = newShoppingList.Id }, inMemoryList.ToShoppingListDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShoppingListDto dto)
    {
        var user = GetSendingUser();
        if (user == null)
        {
            return BadRequest("user not found");
        }

        var inMemoryList = await _shoppingListService.UpdateAsync(user, id, dto.ToShoppingListFromUpdateDto());
        return inMemoryList == null ? NotFound() : Ok(inMemoryList.ToShoppingListDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = GetSendingUser();
        if (user == null)
        {
            return BadRequest("user not found");
        }
        
        var inMemoryList = await _shoppingListService.DeleteAsync(user, id);

        return inMemoryList == null? NotFound(): NoContent();
    }
    
    private AppUser? GetSendingUser()
    {
        var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        return _userManager.Users.FirstOrDefault(u => u.Email == username);
    }
}