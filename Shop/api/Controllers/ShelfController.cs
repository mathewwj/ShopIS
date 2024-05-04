using api.Dto.Product;
using api.Dto.Shelf;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/shelf")]
[ApiController]
public class ShelfController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IProductService _productService;

    public ShelfController(IShelfService shelfService, ICategoryService categoryService, IProductService productService)
    {
        _shelfService = shelfService;
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _shelfService.GetAllAsync();
        var categoriesDto = categories.Select(c => c.ToShelfDto());
        return Ok(categoriesDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var inMemoryShelf = await _shelfService.GetByIdAsync(id);
        if (inMemoryShelf == null)
        {
            return NotFound();
        }
        return Ok(inMemoryShelf.ToShelfDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShelfDto shelfDto)
    {
        var newShelf = shelfDto.ToShelfFromCreateDto();
        
        var inMemoryShelf = await _shelfService.CreateAsync(newShelf);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryShelf.Id }, inMemoryShelf.ToShelfDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShelfDto shelfDto)
    {
        var toUpdateShelf = shelfDto.ToShelfFromUpdateDto();

        var inMemoryShelf = await _shelfService.UpdateAsync(id, toUpdateShelf);
        return inMemoryShelf == null? NotFound(): Ok(inMemoryShelf.ToShelfDto());
    }
    
    [HttpPatch("{shelfId}/move")]
    public async Task<IActionResult> MoveProduct(int shelfId, int toShelfId, int productId)
    {
        if (!await _productService.IsExistsAsync(productId) || 
            !await _shelfService.IsExistsAsync(toShelfId) ||
            !await _shelfService.IsExistsAsync(shelfId))
        {
            return NotFound("invalid product or shelf id");
        }

        var success = await _shelfService.MoveProductAsync(shelfId, toShelfId, productId);

        return success
            ? Ok($"Product {productId} moved from shelf {shelfId} to shelf {toShelfId}")
            : BadRequest("Product move failed");
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var inMemoryShelf = await _shelfService.DeleteAsync(id);

        return inMemoryShelf == null? NotFound(): NoContent();
    }
}