using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace api.Services.Impl;

public class ShelfService : IShelfService
{
    private readonly ApplicationDbContext _context;

    public ShelfService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Shelf>> GetAllAsync()
    {
        return await _context.Shelves
            .Include(s => s.Products)
            .ThenInclude(p => p.Category)
            .ToListAsync();
    }

    public async Task<Shelf?> GetByIdAsync(int id)
    {
        return await _context.Shelves            
            .Include(s => s.Products)
            .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Shelf> CreateAsync(Shelf shelf)
    {
        await _context.Shelves.AddAsync(shelf);
        await _context.SaveChangesAsync();
        return shelf;
    }

    public async Task<Shelf?> UpdateAsync(int id, Shelf shelf)
    {
        var inMemoryShelf = await GetByIdAsync(id);
        if (inMemoryShelf == null)
        {
            return null;
        }

        inMemoryShelf.Name = shelf.Name;
        inMemoryShelf.IsInWarehouse = shelf.IsInWarehouse;
        
        await _context.SaveChangesAsync();
        
        return inMemoryShelf;
    }

    public async Task<Shelf?> DeleteAsync(int id)
    {
        var inMemoryShelf = await GetByIdAsync(id);
        if (inMemoryShelf == null)
        {
            return null;
        }

        var moveToShelfId = await _context.Shelves
            .Where(x => x.IsInWarehouse)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        foreach (var product in inMemoryShelf.Products)
        {
            product.ShelfId = moveToShelfId;
        }
        
        _context.Shelves.Remove(inMemoryShelf);
        await _context.SaveChangesAsync();
        return inMemoryShelf;
    }

    public async Task<bool> MoveProductAsync(int fromId, int toId, int productId)
    {
        var fromShelf = await GetByIdAsync(fromId);
        var toShelf = await GetByIdAsync(toId);

        if (fromShelf == null || toShelf == null)
        {
            return false;
        }

        var product = fromShelf.Products.FirstOrDefault(x => x.Id == productId);
        if (product == null)
        {
            return false;
        }

        product.ShelfId = toShelf.Id;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await GetByIdAsync(id) != null;
    }
}