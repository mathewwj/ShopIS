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
    public ActionResult GetMap([FromBody] List<int> productIds)
    {
        string content = _pathService.GetSvgPath(productIds);
        return Content(content, "image/svg+xml");
    }
}