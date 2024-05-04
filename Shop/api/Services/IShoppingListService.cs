using api.Models;

namespace api.Services;

public interface IShoppingListService
{
    Task<List<ShoppingList>> GetAllAsync(AppUser appUser);
    Task<ShoppingList?> GetByIdAsync(AppUser appUser, int id);

    Task<ShoppingList> CreateAsync(AppUser appUser, ShoppingList shoppingList);
    Task<ShoppingList?> UpdateAsync(AppUser appUser, int id, ShoppingList shoppingList);
    Task<ShoppingList?> DeleteAsync(AppUser appUser, int id);

    Task<bool> IsExistsAsync(AppUser appUser, int id);
}