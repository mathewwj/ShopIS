using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("join_product_shopping_list")]
public class JoinProductShoppingList
{
    public int ShoppingListId { get; set; }
    public ShoppingList ShoppingList { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}