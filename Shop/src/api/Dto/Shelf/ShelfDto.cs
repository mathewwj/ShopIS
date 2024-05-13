using api.Dto.Category;
using api.Dto.Product;

namespace api.Dto.Shelf;

public class ShelfDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsInWarehouse { get; set; }
    public List<ProductDto> Products { get; set; }
}