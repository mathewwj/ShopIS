using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Impl;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> UpdateAsync(int id, Category category)
    {
        var inMemoryCategory = await GetByIdAsync(id);
        if (inMemoryCategory == null)
        {
            return null;
        }

        inMemoryCategory.Name = category.Name;
        await _context.SaveChangesAsync();
        
        return inMemoryCategory;
    }

    public async Task<Category?> DeleteAsync(int id)
    {
        var inMemoryCategory = await GetByIdAsync(id);
        if (inMemoryCategory == null)
        {
            return null;
        }

        _context.Categories.Remove(inMemoryCategory);
        await _context.SaveChangesAsync();
        return inMemoryCategory;
    }

    public async Task<bool> IsExists(int id)
    {
        return await GetByIdAsync(id) != null;
    }
}