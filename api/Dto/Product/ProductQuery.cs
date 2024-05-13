namespace api.Dto.Product;

public class ProductQuery
{
    public string? Name { get; set; } = null;
    public int? CategoryId { get; set; } = null;
    public int? PriceLower { get; set; } = null;
    public int? PriceUpper { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}