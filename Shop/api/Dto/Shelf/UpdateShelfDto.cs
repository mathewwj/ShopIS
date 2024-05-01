namespace api.Dto.Shelf;

public class UpdateShelfDto
{
    public int Capacity { get; set; }
    public bool IsInWarehouse { get; set; }
    public int CategoryId { set; get; }
}