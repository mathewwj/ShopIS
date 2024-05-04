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
            IsInWarehouse = shelf.IsInWarehouse,
            Name = shelf.Name,
            Products = shelf.Products.Select(x => x.ToProductDto()).ToList()
        };
    }

    public static Shelf ToShelfFromCreateDto(this CreateShelfDto createShelfDto)
    {
        return new Shelf
        {
            Name = createShelfDto.Name,
            IsInWarehouse = createShelfDto.IsInWarehouse,
        };
    }
    
    public static Shelf ToShelfFromUpdateDto(this UpdateShelfDto createShelfDto)
    {
        var shelf = new Shelf
        {
            Name = createShelfDto.Name,
            IsInWarehouse = createShelfDto.IsInWarehouse,
        };
        
        return shelf;
    }
}