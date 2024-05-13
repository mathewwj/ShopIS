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
    private readonly IAuthService _authService;

    public ShoppingListController(IShoppingListService shoppingListService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IAuthService authService)
    {
        _shoppingListService = shoppingListService;
        _authService = authService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var user = await _authService.GetAppUser(User);
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
        var user = await _authService.GetAppUser(User);
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
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateShoppingListDto shoppingListDto)
    {
        var user = await _authService.GetAppUser(User);
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
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShoppingListDto dto)
    {
        var user = await _authService.GetAppUser(User);
        if (user == null)
        {
            return BadRequest("user not found");
        }

        var inMemoryList = await _shoppingListService.UpdateAsync(user, id, dto.ToShoppingListFromUpdateDto());
        return inMemoryList == null ? NotFound() : Ok(inMemoryList.ToShoppingListDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = await _authService.GetAppUser(User);
        if (user == null)
        {
            return BadRequest("user not found");
        }
        
        var inMemoryList = await _shoppingListService.DeleteAsync(user, id);

        return inMemoryList == null? NotFound(): NoContent();
    }
}