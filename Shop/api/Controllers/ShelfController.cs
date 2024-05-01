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
    private readonly ICategoryService _categoryService;

    public ShelfController(IShelfService shelfService, ICategoryService categoryService)
    {
        _shelfService = shelfService;
        _categoryService = categoryService;
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
        
        if (!await _categoryService.IsExistsAsync(newShelf.CategoryId))
        {
            return NotFound("invalid category id");
        }
        
        var inMemoryShelf = await _shelfService.CreateAsync(newShelf);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryShelf.Id }, inMemoryShelf.ToShelfDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShelfDto shelfDto)
    {
        var toUpdateShelf = shelfDto.ToShelfFromUpdateDto();
        
        if (!await _categoryService.IsExistsAsync(toUpdateShelf.CategoryId))
        {
            return NotFound("invalid category id");
        }
        
        var inMemoryShelf = await _shelfService.UpdateAsync(id, toUpdateShelf);
        return inMemoryShelf == null? NotFound(): Ok(inMemoryShelf.ToShelfDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var inMemoryShelf = await _shelfService.DeleteAsync(id);

        return inMemoryShelf == null? NotFound(): NoContent();
    }
}