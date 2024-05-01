using api.Dto.ShelfProduct;
using api.Models;

namespace api.Mappers;

public static class ShelfProductMapper
{
    public static ShelfProductDto ShelfProductDto(this ShelfProduct shelfProduct)
    {
        return new ShelfProductDto
        {
            ProductDto = shelfProduct.Product.ToProductDto(),
            Quantity = shelfProduct.Quantity
        };
    }
}