using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Impl;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        product.ShelfId = await _context.Shelves
            .Where(x => x.IsInWarehouse)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        await _context.Entry(product).Reference(p => p.Category).LoadAsync();

        return product;
    }

    public async Task<Product?> UpdateAsync(int id, Product product)
    {
        var inMemoryProduct = await GetByIdAsync(id);
        if (inMemoryProduct == null)
        {
            return null;
        }

        inMemoryProduct.Name = product.Name;
        inMemoryProduct.CategoryId = product.CategoryId;
        inMemoryProduct.DescriptionUrl = product.DescriptionUrl;
        inMemoryProduct.ImageUrl = product.ImageUrl;
        inMemoryProduct.Price = product.Price;

        await _context.SaveChangesAsync();

        return inMemoryProduct;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        var inMemoryProduct = await GetByIdAsync(id);
        if (inMemoryProduct == null)
        {
            return null;
        }

        _context.Products.Remove(inMemoryProduct);
        await _context.SaveChangesAsync();
        return inMemoryProduct;
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await GetByIdAsync(id) != null;
    }
}