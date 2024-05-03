using api.Data;
using Microsoft.EntityFrameworkCore;
using SVGUtils;

namespace api.Services.Impl;

public class PathService : IPathService
{
    private readonly ApplicationDbContext _context;
    private readonly ISvgMapManager _mapManager;
    private static string BASE_PATH = "./";
    private static string TEMP_PATH = BASE_PATH + "Temp/";
    private static string MAP_PATH = TEMP_PATH + "floor_plan.svg";

    public PathService(ApplicationDbContext context)
    {
        _context = context;
        _mapManager = new SvgMapManager();
    }

    // TODO async
    public string GetSvgPath(List<int> productIds)
    {
        var shelfIds = _context.Products
            .Include(p => p.ShelfId)
            .Where(p => productIds.Contains(p.Id))
            .Select(p => p.ShelfId)
            .ToList();
        
        _mapManager.LoadMap(MAP_PATH);
        
        var name = TEMP_PATH + "a";
        _mapManager.CreatePath(name, shelfIds);
        
        return File.ReadAllText(name);
        
    }
}