using api.Dto.Product;

namespace api.Dto.ShoppingList;

public class UpdateShoppingListDto
{
    public string Name { get; set; }
    public List<ProductDto> ProductDtos { get; set; }
}