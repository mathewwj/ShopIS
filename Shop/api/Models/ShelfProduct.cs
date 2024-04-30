using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("shelf_product")]
public class ShelfProduct
{
    public int ShelfId { get; set; }
    public Shelf Shelf { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
}