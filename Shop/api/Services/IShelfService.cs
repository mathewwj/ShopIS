using api.Models;

namespace api.Services;

public interface IShelfService
{
    Task<List<Shelf>> GetAllAsync();
    Task<Shelf?> GetByIdAsync(int id);

    Task<Shelf> CreateAsync(Shelf shelf);
    Task<Shelf?> UpdateAsync(int id, Shelf shelf);
    Task<Shelf?> DeleteAsync(int id);
    
    Task<bool> IsExistsAsync(int id);
}