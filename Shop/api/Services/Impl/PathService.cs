using api.Data;
using api.Migrations;
using api.Models;
using SVGUtils;
using Microsoft.EntityFrameworkCore;

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
    public string GetSvgPath(ShoppingList shoppingList)
    {
        var map = AbsoluteToRelativeShelfId();
        
        var productIds = shoppingList.JoinProductShoppingLists.Select(jp => jp.Product.Id).ToList();
        
        var shelfIds = _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => p.ShelfId)
            .Select(id => map[id])
            .ToList();
        
        _mapManager.LoadMap(MAP_PATH);
        
        var name = TEMP_PATH + "out.svg";
        _mapManager.CreatePath(name, shelfIds);
        
        return File.ReadAllText(name);
        
    }

    private Dictionary<int, int> AbsoluteToRelativeShelfId()
    {
        Dictionary<int, int> mapper = new();

        var shift = 0;
        var last = int.MinValue;

        foreach (var shelf in _context.Shelves)
        {
            if (last == int.MinValue)
            {
                last = shelf.Id - 1;
            }

            shift += shelf.Id - last - 1;
            
            if (shelf.IsInWarehouse)
            {
                shift++;
            }
            else
            {
                mapper.Add(shelf.Id, shelf.Id - shift);
            }
            last = shelf.Id;
        }
        

        return mapper;
    }
}