using api.Dto.Product;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        var categoriesDto = products.Select(c => c.ToProductDto());
        return Ok(categoriesDto);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var inMemoryProduct = await _productService.GetByIdAsync(id);
        if (inMemoryProduct == null)
        {
            return NotFound();
        }
        return Ok(inMemoryProduct.ToProductDto());
    }
 
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        var newProduct = productDto.ToProductFromCreateDto();
        var inMemoryProduct = await _productService.CreateAsync(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryProduct.Id }, inMemoryProduct.ToProductDto());
    }
}