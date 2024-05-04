using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Services.Impl;

public class ShoppingListService : IShoppingListService
{
    private readonly ApplicationDbContext _context;
    private readonly IJoinProductShoppingListService _joinService;
    private readonly IProductService _productService;

    public ShoppingListService(ApplicationDbContext context, IJoinProductShoppingListService joinService, IProductService productService)
    {
        _context = context;
        _joinService = joinService;
        _productService = productService;
    }

    public async Task<List<ShoppingList>> GetAllAsync(AppUser appUser)
    {
        return await _context.ShoppingLists
            .Where(sl => sl.AppUserId == appUser.Id)
            .Include(sl => sl.AppUser)
            .Include(sl => sl.JoinProductShoppingLists)
            .ThenInclude(j => j.Product)
            .ThenInclude(p => p.Category)
            .ToListAsync();
    }

    public async Task<ShoppingList?> GetByIdAsync(AppUser appUser, int id)
    {
        return await _context.ShoppingLists
            .Where(sl => sl.AppUserId == appUser.Id && sl.Id == id)
            .Include(sl => sl.AppUser)
            .Include(sl => sl.JoinProductShoppingLists)
            .ThenInclude(j => j.Product)
            .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync();
    }

    public async Task<ShoppingList> CreateAsync(AppUser appUser, ShoppingList shoppingList)
    {
        shoppingList.AppUser = appUser;
        shoppingList.AppUserId = appUser.Id;

        await _context.ShoppingLists.AddAsync(shoppingList);
        await _context.SaveChangesAsync();
        return shoppingList;
    }

    public async Task<ShoppingList?> UpdateAsync(AppUser appUser, int id, ShoppingList shoppingList)
    {
        var inMemoryList = await GetByIdAsync(appUser, id);
        if (inMemoryList == null)
        {
            return null;
        }

        inMemoryList.Name = shoppingList.Name;
        var products = shoppingList.JoinProductShoppingLists;
        
        // check exists all
        foreach (var product in products)
        {
            if (!await _productService.IsExistsAsync(product.ProductId))
            {
                return null;
            }
        }
        
        _context.JoinProductShoppingLists.RemoveRange(inMemoryList.JoinProductShoppingLists);
        foreach (var product in products)
        {
            await _joinService.AddProductToShoppingList(inMemoryList.Id, product.ProductId);
        }
        
        
        await _context.SaveChangesAsync();
        
        return inMemoryList;
    }

    public async Task<ShoppingList?> DeleteAsync(AppUser appUser, int id)
    {
        var inMemoryList = await GetByIdAsync(appUser, id);
        if (inMemoryList == null)
        {
            return null;
        }
        
        _context.ShoppingLists.Remove(inMemoryList);
        await _context.SaveChangesAsync();

        return inMemoryList;
    }

    public async Task<bool> IsExistsAsync(AppUser appUser, int id)
    {
        return await GetByIdAsync(appUser,id) != null;
    }
}