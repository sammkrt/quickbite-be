using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishesController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishesController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Dish>> GetRestaurantById(int id) 
        => await _dishService.QueryDishById(id);
}