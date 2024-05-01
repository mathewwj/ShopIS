using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("shelf")]
public class Shelf
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public bool IsInWarehouse { get; set; }
    
    // Navigation property
    public int CategoryId { set; get; }
    public Category Category { get; set; }
    
    // Products
    public List<ShelfProduct> ShelfProducts { get; set; } = new();
}