using api.Models;

namespace api.Services;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);

    Task<Product> CreateAsync(Product product);
    Task<Product?> UpdateAsync(int id, Product product);
    Task<Product?> DeleteAsync(int id);

    Task<bool> IsExistsAsync(int id);
}