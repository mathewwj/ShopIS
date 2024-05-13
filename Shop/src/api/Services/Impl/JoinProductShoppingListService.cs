using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Impl;

public class JoinProductShoppingListService : IJoinProductShoppingListService
{
    private readonly ApplicationDbContext _context;

    public JoinProductShoppingListService(ApplicationDbContext context, IProductService productService)
    {
        _context = context;
    }

    public async Task AddProductToShoppingList(int shoppingListId, int productId)
    {
        var join = new JoinProductShoppingList
        {
            ShoppingListId = shoppingListId,
            ProductId = productId
        };

        _context.JoinProductShoppingLists.Add(join);
        await _context.SaveChangesAsync();
    }

    public async  Task<List<Product>> GetProductsInShoppingList(int shoppingListId)
    {
        return await _context.JoinProductShoppingLists
            .Where(j => j.ShoppingListId == shoppingListId)
            .Select(j => j.Product)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task RemoveProductFromShoppingList(int shoppingListId, int productId)
    {
        var shoppingListProduct = await _context.JoinProductShoppingLists
            .SingleOrDefaultAsync(sp => sp.ShoppingListId == shoppingListId 
                                        && sp.ProductId == productId);

        if (shoppingListProduct != null)
        {
            _context.JoinProductShoppingLists.Remove(shoppingListProduct);
            await _context.SaveChangesAsync();
        }
    }
}