﻿using api.Dto.Product;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService, IShelfService shelfService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductQuery query)
    {
        var products = await _productService.GetAllAsync();

        
        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            products = products.Where(p => p.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        if (query.CategoryId != null)
        {
            products = products.Where(p => p.CategoryId == query.CategoryId).ToList();
        }
        if (query.PriceLower != null)
        {
            products = products.Where(p => p.Price >= query.PriceLower).ToList();
        }
        if (query.PriceUpper != null)
        {
            products = products.Where(p => p.Price <= query.PriceUpper).ToList();
        }

        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                products = query.IsDescending
                    ? products.OrderByDescending(p => p.Name).ToList()
                    : products.OrderBy(p => p.Name).ToList();
            }
            if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
            {
                products = query.IsDescending
                    ? products.OrderByDescending(p => p.Price).ToList()
                    : products.OrderBy(p => p.Price).ToList();
            }
        }
        
        var productDtos = products.Select(c => c.ToProductDto());
        return Ok(productDtos);
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
 
    // TODO fix create return null category
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        var newProduct = productDto.ToProductFromCreateDto();
        var inMemoryProduct = await _productService.CreateAsync(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = inMemoryProduct.Id }, inMemoryProduct.ToProductDto());
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto productDto)
    {
        var toUpdateProduct = productDto.ToProductFromUpdateDto();
        
        if (!await _categoryService.IsExistsAsync(toUpdateProduct.CategoryId))
        {
            return NotFound("invalid category id");
        }
        
        var inMemoryCategory = await _productService.UpdateAsync(id, toUpdateProduct);
        return inMemoryCategory == null? NotFound(): Ok(inMemoryCategory.ToProductDto());
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var inMemoryProduct = await _productService.DeleteAsync(id);

        return inMemoryProduct == null? NotFound(): NoContent();
    }
}