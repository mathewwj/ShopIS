using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("shopping_list")]
public class ShoppingList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTime { get; set; }

    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public List<JoinProductShoppingList> JoinProductShoppingLists { get; set; } = new();
}