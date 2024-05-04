using api.Dto.ShoppingList;
using api.Models;

namespace api.Mappers;

public static class ShoppingListMapper
{
    public static ShoppingListDto ToShoppingListDto(this ShoppingList shoppingList)
    {
        return new ShoppingListDto
        {
            Id = shoppingList.Id,
            Name = shoppingList.Name,
            CreatedTime = shoppingList.CreatedTime,
            ProductDtos = shoppingList.JoinProductShoppingLists.Select(j => j.Product.ToProductDto()).ToList()
        };
    }

    public static ShoppingList ToShoppingListFromCreateDto(this CreateShoppingListDto dto)
    {
        return new ShoppingList
        {
            Name = dto.Name,
            CreatedTime = DateTime.Now
        };
    }
    
    public static ShoppingList ToShoppingListFromUpdateDto(this UpdateShoppingListDto dto)
    {
        return new ShoppingList
        {
            Name = dto.Name,
            JoinProductShoppingLists = dto.ProductDtos.Select(p => new JoinProductShoppingList{ProductId = p.Id}).ToList()
        };
    }
    
}