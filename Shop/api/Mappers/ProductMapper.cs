using api.Dto.Product;
using api.Models;

namespace api.Mappers;

public static class ProductMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            CategoryDto = product.Category.ToCategoryDto(),
            DescriptionUrl = product.DescriptionUrl,
            ImageUrl = product.ImageUrl,
            Price = product.Price
        };
    }
    
    public static Product ToProductFromCreateDto(this CreateProductDto createProductDto)
    {
        return new Product
        {
            Name = createProductDto.Name,
            CategoryId = createProductDto.CategoryId,
            DescriptionUrl = createProductDto.DescriptionUrl,
            ImageUrl = createProductDto.ImageUrl,
            Price = createProductDto.Price
        };
    }
    
    public static Product ToProductFromUpdateDto(this UpdateProductDto updateProductDto)
    {
        return new Product
        {
            Name = updateProductDto.Name,
            CategoryId = updateProductDto.CategoryId,
            DescriptionUrl = updateProductDto.DescriptionUrl,
            ImageUrl = updateProductDto.ImageUrl,
            Price = updateProductDto.Price
        };
    }
    
    public static Product ToProductFromDto(this ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            CategoryId = productDto.CategoryDto.Id,
            Category = productDto.CategoryDto.ToCategoryFromDto(),
            DescriptionUrl = productDto.DescriptionUrl,
            ImageUrl = productDto.ImageUrl,
            Price = productDto.Price
        };
    }
    
}