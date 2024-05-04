using api.Models;

namespace api.Services.Impl;

public interface IJoinProductShoppingListService
{
    Task AddProductToShoppingList(int shoppingListId, int productId);
    Task<List<Product>> GetProductsInShoppingList(int shoppingListId);
    Task RemoveProductFromShoppingList(int shoppingListId, int productId);
}