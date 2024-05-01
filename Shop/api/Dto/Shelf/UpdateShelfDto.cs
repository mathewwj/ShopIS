using api.Dto.ShelfProduct;

namespace api.Dto.Shelf;

public class UpdateShelfDto
{
    public int Capacity { get; set; }
    public bool IsInWarehouse { get; set; }
    public int CategoryId { set; get; }
    public List<ShelfProductDto> ShelfProductDtos { get; set; } = new();
}