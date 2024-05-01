using api.Dto.Product;
using api.Models;

namespace api.Mappers;

public static class ProductMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            Name = product.Name,
            Category = product.Category,
            DescriptionUrl = product.DescriptionUrl,
            ImageUrl = product.ImageUrl,
            Price = product.Price
        };
    }
}