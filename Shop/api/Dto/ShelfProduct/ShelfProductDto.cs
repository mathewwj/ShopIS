using api.Dto.Product;

namespace api.Dto.ShelfProduct;

public class ShelfProductDto
{
    public ProductDto ProductDto { get; set;}
    public int Quantity { get; set; }
}