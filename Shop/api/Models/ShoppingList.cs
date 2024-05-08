using System.ComponentModel.DataAnnotations.Schema;
using static System.String;

namespace api.Models;

[Table("shopping_list")]
public class ShoppingList
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedTime { get; set; }

    public string AppUserId { get; set; } = string.Empty;
    public AppUser AppUser { get; set; }

    public List<JoinProductShoppingList> JoinProductShoppingLists { get; set; } = new();
}