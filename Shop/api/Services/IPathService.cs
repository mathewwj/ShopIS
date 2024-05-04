using api.Models;

namespace api.Services;

public interface IPathService
{
    string GetSvgPath(ShoppingList shoppingList);
}