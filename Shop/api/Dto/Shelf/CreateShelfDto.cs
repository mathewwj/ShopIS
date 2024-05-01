namespace api.Dto.Shelf;

public class CreateShelfDto
{
    public int Capacity { get; set; }
    public bool IsInWarehouse { get; set; }
    public int CategoryId { set; get; }
}