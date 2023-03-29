using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishesController : ControllerBase
{
    private IDishService DishService { get; set; }

    public DishesController(IDishService dishService)
    {
        DishService = dishService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Dish>> GetRestaurantById(int id)
    {
        var dish = await DishService.QueryDishById(id);

        if (id == null || dish == null)
            return NotFound();

        return dish;
    }
}