using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/map")]
[ApiController]
public class MapController : ControllerBase
{
    private readonly IPathService _pathService;
    private readonly IShoppingListService _shoppingListService;
    private readonly IAuthService _authService;

    public MapController(IPathService pathService, IShoppingListService shoppingListService, IAuthService authService)
    {
        _pathService = pathService;
        _shoppingListService = shoppingListService;
        _authService = authService;
    }

    [HttpGet]
    [Authorize]
    [Route("{id:int}")]
    public async Task<ActionResult> GetMap([FromRoute] int id)
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
        
        var content = await _pathService.GetSvgPath(shoppingList);
        return Content(content, "image/svg+xml");
    }
}