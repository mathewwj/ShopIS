using api.Models;

namespace api.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);

    Task<Category> CreateAsync(Category category);
    Task<Category?> UpdateAsync(int id, Category category);
    Task<Category?> DeleteAsync(int id);

    Task<bool> IsExists(int id);
}