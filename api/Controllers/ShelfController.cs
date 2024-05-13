using api.Dto.Product;
using api.Dto.Shelf;
using api.Mappers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/shelf")]
[ApiController]
public class ShelfController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IProductService _productService;
    private readonly IAuthService _authService;

    public ShelfController(IShelfService shelfService, ICategoryService categoryService, IProductService productService, IAuthService authService)
    {
        _shelfService = shelfService;
        _productService = productService;
        _authService = authService;
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
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateShelfDto shelfDto)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");
        
        var newShelf = shelfDto.ToShelfFromCreateDto();
        
        var inMemoryShelf = await _shelfService.CreateAsync(newShelf);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryShelf.Id }, inMemoryShelf.ToShelfDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShelfDto shelfDto)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");
        
        var toUpdateShelf = shelfDto.ToShelfFromUpdateDto();

        var inMemoryShelf = await _shelfService.UpdateAsync(id, toUpdateShelf);
        return inMemoryShelf == null? NotFound(): Ok(inMemoryShelf.ToShelfDto());
    }
    
    [HttpPatch("{shelfId}/move")]
    [Authorize]
    public async Task<IActionResult> MoveProduct(int shelfId, int toShelfId, int productId)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");
        
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
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!await _authService.IsValidRole(User, UserRole.Admin))
            return StatusCode(StatusCodes.Status403Forbidden, "You do not have permission to access this resource.");
        
        var inMemoryShelf = await _shelfService.DeleteAsync(id);

        return inMemoryShelf == null? NotFound(): NoContent();
    }
}