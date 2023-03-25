using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private IRestaurantService RestaurantService { get; set; }
    private IDishService DishService { get; set; }

    public RestaurantsController(IRestaurantService restaurantService, IDishService dishService)
    {
        RestaurantService = restaurantService;
        DishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants() =>
        await RestaurantService.GetAllRestaurants(); // Check if Empty. If empty, return BadRequest

    [HttpGet]
    [Route("search/{input}")]
    public async Task<ActionResult<List<Restaurant>>> FilterRestaurantsFromSearch(string input)
        => await RestaurantService.FilterRestaurantsBySearchBar(input);

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
    {
        if (id == null)
            return NotFound();

        var restaurantFromDb = await RestaurantService.GetRestaurantById(id);

        if (restaurantFromDb == null)
            return NotFound();

        return restaurantFromDb;
    }
}