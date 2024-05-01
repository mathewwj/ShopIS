using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("products")]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Category
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public string DescriptionUrl { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    // Products
    public List<ShelfProduct> ShelfProducts { get; set; } = new();
}