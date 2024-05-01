using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("categories")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // navigation
    public List<Product> Products { get; set; }
}
