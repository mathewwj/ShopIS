using api.Dto.Shelf;
using api.Models;

namespace api.Mappers;

public static class ShelfMapper
{
    public static ShelfDto ToShelfDto(this Shelf shelf)
    {
        return new ShelfDto
        {
            Id = shelf.Id,
            Capacity = shelf.Capacity,
            IsInWarehouse = shelf.IsInWarehouse,
            Category = shelf.Category.ToCategoryDto(),
            Products = shelf.Products.Select(x => x.ToProductDto()).ToList()
        };
    }

    public static Shelf ToShelfFromCreateDto(this CreateShelfDto createShelfDto)
    {
        return new Shelf
        {
            Capacity = createShelfDto.Capacity,
            IsInWarehouse = createShelfDto.IsInWarehouse,
            CategoryId = createShelfDto.CategoryId,
        };
    }
    
    public static Shelf ToShelfFromUpdateDto(this UpdateShelfDto createShelfDto)
    {
        var shelf = new Shelf
        {
            Capacity = createShelfDto.Capacity,
            IsInWarehouse = createShelfDto.IsInWarehouse,
            CategoryId = createShelfDto.CategoryId
        };
        
        return shelf;
    }
}