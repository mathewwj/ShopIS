using api.Dto.Category;
using api.Mappers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IAuthService _authService;

    public CategoryController(ICategoryService categoryService, IAuthService authService)
    {
        _categoryService = categoryService;
        _authService = authService;
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
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryDto)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");
        
        var newCategory = categoryDto.ToCategoryFromCreateDto();
        var inMemoryCategory = await _categoryService.CreateAsync(newCategory);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryCategory.Id }, inMemoryCategory.ToCategoryDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDto categoryDto)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");

        var inMemoryCategory = await _categoryService.UpdateAsync(id, categoryDto.ToCategoryFromUpdateDto());
        
        return inMemoryCategory == null? NotFound(): Ok(inMemoryCategory.ToCategoryDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");

        var inMemoryCategory = await _categoryService.DeleteAsync(id);

        return inMemoryCategory == null? NotFound(): NoContent();
    }
}