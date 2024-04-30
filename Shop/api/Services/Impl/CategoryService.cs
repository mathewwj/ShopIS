using api.Models;

namespace api.Services.Impl;

public class CategoryService : ICategoryService
{
    public Task<List<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
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