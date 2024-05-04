using api.Dto.ShoppingList;
using api.Mappers;
using api.Models;
using api.Services;
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
    public ActionResult GetMap([FromBody] ShoppingListDto shoppingListDto)
    {
        string content = _pathService.GetSvgPath(shoppingListDto.ToShoppingListFromDto());
        return Content(content, "image/svg+xml");
    }
}