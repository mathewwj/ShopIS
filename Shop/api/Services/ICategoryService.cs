using api.Models;

namespace api.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);

    Task<Category> CreateAsync(Category Category);
    Task<Category?> UpdateAsync(int id, Category Category);
    Task<Category?> Delete(int id);
}