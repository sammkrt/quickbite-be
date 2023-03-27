using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dish>>> GetAllDishesAsync()
    {
        var dishes = await _dishService.GetAllDishesAsync();

        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<Dish>> GetDishByIdAsync(int dishId)
    {
        var dish = await _dishService.GetDishByIdAsync(dishId);

        if (dish == null)
        {
            return NotFound();
        }

        return Ok(dish);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Dish>>> GetDishesByCategoryIdAsync(int categoryId)
    {
        var dishes = await _dishService.GetDishesByCategoryIdAsync(categoryId);

        return Ok(dishes);
    }

    [HttpPost]
    public async Task<ActionResult<Dish>> CreateDishAsync([FromBody] Dish dish)
    {
        var newDish = await _dishService.CreateDishAsync(dish);

        return Ok(newDish);
    }

    [HttpPut("{dishId}")]
    public async Task<ActionResult<Dish>> UpdateDishAsync(int dishId, [FromBody] Dish dish)
    {
        var updatedDish = await _dishService.UpdateDishAsync(dishId, dish);

        return Ok(updatedDish);
    }

    [HttpDelete("{dishId}")]
    public async Task<ActionResult> DeleteDishAsync(int dishId)
    {
        await _dishService.DeleteDishAsync(dishId);

        return Ok();
    }
}
