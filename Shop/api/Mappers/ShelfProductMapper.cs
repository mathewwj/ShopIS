using api.Dto.ShelfProduct;
using api.Models;

namespace api.Mappers;

public static class ShelfProductMapper
{
    public static ShelfProductDto ToShelfProductDto(this ShelfProduct shelfProduct)
    {
        return new ShelfProductDto
        {
            ProductDto = shelfProduct.Product.ToProductDto(),
            Quantity = shelfProduct.Quantity
        };
    }

    public static ShelfProduct ToShelfProductFromDto(this ShelfProductDto shelfProductDto)
    {
        return new ShelfProduct
        {
            Product = shelfProductDto.ProductDto.ToProductFromDto(),
            ProductId = shelfProductDto.ProductDto.Id,
        };
    }
}