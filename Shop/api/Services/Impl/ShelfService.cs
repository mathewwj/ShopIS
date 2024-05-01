using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Shelves.Include(s => s.Category).ToListAsync();
    }

    public async Task<Shelf?> GetByIdAsync(int id)
    {
        return await _context.Shelves.Include(s => s.Category).FirstOrDefaultAsync(x => x.Id == id);
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

        inMemoryShelf.Capacity = shelf.Capacity;
        inMemoryShelf.IsInWarehouse = shelf.IsInWarehouse;
        inMemoryShelf.CategoryId = shelf.CategoryId;
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

        _context.Shelves.Remove(inMemoryShelf);
        await _context.SaveChangesAsync();
        return inMemoryShelf;
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await GetByIdAsync(id) != null;
    }
}