using System.ComponentModel.DataAnnotations.Schema;
using api.Dto.Category;

namespace api.Dto.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryDto CategoryDto { get; set; }
    public string DescriptionUrl { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
}