using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dto.Product;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    public Models.Category Category { get; set; }
    public string DescriptionUrl { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
}