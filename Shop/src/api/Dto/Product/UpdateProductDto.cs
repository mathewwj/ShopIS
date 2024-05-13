namespace api.Dto.Product;

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string DescriptionUrl { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
}