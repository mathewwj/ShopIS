using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("shelf")]
public class Shelf
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsInWarehouse { get; set; }
    
    // Products
    public List<Product> Products { get; set; } = new();
}