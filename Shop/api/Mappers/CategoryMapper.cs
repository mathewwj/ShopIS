using api.Dto.Category;
using api.Models;

namespace api.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static Category ToCategoryFromCreateDto(this CreateCategoryDto createCategoryDto)
    {
        return new Category
        {
            Name = createCategoryDto.Name
        };
    }
    
    public static Category ToCategoryFromUpdateDto(this UpdateCategoryDto createCategoryDto)
    {
        return new Category
        {
            Name = createCategoryDto.Name
        };
    }
}