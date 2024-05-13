using api.Dto.ShoppingList;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/map")]
[ApiController]
public class MapController : ControllerBase
{
    private readonly IPathService _pathService;

    public MapController(IPathService pathService)
    {
        _pathService = pathService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> GetMap([FromBody] ShoppingListDto shoppingListDto)
    {
        var content = await _pathService.GetSvgPath(shoppingListDto.ToShoppingListFromDto());
        return Content(content, "image/svg+xml");
    }
}