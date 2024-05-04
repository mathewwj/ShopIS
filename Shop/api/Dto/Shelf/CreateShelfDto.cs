namespace api.Dto.Shelf;

public class CreateShelfDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsInWarehouse { get; set; }
}