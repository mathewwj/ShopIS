﻿using api.Dto.Category;
using api.Dto.ShelfProduct;

namespace api.Dto.Shelf;

public class ShelfDto
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public bool IsInWarehouse { get; set; }
    public CategoryDto Category { get; set; }
    public List<ShelfProductDto> ShelfProductDtos { get; set; }
}