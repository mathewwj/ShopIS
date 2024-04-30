using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

// todo rename table
[Table("product_categories")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // navigation
    public List<Product> Products { get; set; }
}