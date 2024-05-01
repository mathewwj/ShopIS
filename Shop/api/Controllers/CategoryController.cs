using api.Dto.Category;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        var categoriesDto = categories.Select(c => c.ToCategoryDto());
        return Ok(categoriesDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var inMemoryCategory = await _categoryService.GetByIdAsync(id);
        if (inMemoryCategory == null)
        {
            return NotFound();
        }
        return Ok(inMemoryCategory.ToCategoryDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryDto)
    {
        var newCategory = categoryDto.ToCategoryFromCreateDto();
        var inMemoryCategory = await _categoryService.CreateAsync(newCategory);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryCategory.Id }, inMemoryCategory.ToCategoryDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDto categoryDto)
    {
        var inMemoryCategory = await _categoryService.UpdateAsync(id, categoryDto.ToCategoryFromUpdateDto());
        
        return inMemoryCategory == null? NotFound(): Ok(inMemoryCategory.ToCategoryDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var inMemoryCategory = await _categoryService.DeleteAsync(id);

        return inMemoryCategory == null? NotFound(): NoContent();
    }
}