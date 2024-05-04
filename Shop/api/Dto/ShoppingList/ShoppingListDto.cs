using api.Dto.Product;

namespace api.Dto.ShoppingList;

public class ShoppingListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTime { get; set; }
    public List<ProductDto> ProductDtos { get; set; }
}