using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Impl;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _applicationDbContext.Categories.ToListAsync();
    }

    public Task<Category?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> CreateAsync(Category Category)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> UpdateAsync(int id, Category CategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> Delete(int id)
    {
        throw new NotImplementedException();
    }
}