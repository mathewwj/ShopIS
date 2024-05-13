using api.Dto.Product;

namespace api.Dto.Shelf;

public class UpdateShelfDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsInWarehouse { get; set; }
}