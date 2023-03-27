using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    public async Task<ActionResult<Category>> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
    {
        var category = await _categoryService.CreateCategoryAsync(request.Category);

        return Ok(category);
    }

    [HttpPut("{categoryId}")]
    public async Task<ActionResult<Category>> UpdateCategoryAsync(int categoryId, [FromBody] UpdateCategoryRequest request)
    {
        var category = await _categoryService.UpdateCategoryAsync(categoryId, request.Category);

        return Ok(category);
    }

    [HttpDelete("{categoryId}")]
    public async Task<ActionResult> DeleteCategoryAsync(int categoryId)
    {
        await _categoryService.DeleteCategoryAsync(categoryId);

        return Ok();
    }
}

public class CreateCategoryRequest
{
    public string Category { get; set; }
}

public class UpdateCategoryRequest
{
    public string Category { get; set; }
}
