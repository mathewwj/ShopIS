using api.Models;

namespace api.Services;

public interface IPathService
{
    Task<string> GetSvgPath(ShoppingList shoppingList);
}