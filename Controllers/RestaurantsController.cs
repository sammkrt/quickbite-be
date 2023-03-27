using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private IRestaurantService _restaurantService { get; set; }
    private IDishService DishService { get; set; }

    public RestaurantsController(IRestaurantService restaurantService, IDishService dishService)
    {
        _restaurantService = restaurantService;
        DishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants() =>
        await _restaurantService.GetAllRestaurants(); // Check if Empty. If empty, return BadRequest

    [HttpGet]
    [Route("search/{input}")]
    public async Task<ActionResult<List<Restaurant>>> FilterRestaurantsFromSearch(string input)
        => await _restaurantService.FilterRestaurantsBySearchBar(input);

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
    {
        if (id == null)
            return NotFound();

        var restaurantFromDb = await _restaurantService.GetRestaurantById(id);

        if (restaurantFromDb == null)
            return NotFound();

        return restaurantFromDb;
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> AddRestaurant(AddRestaurantRequest request)
    {
        return await _restaurantService.CreateRestaurant(request);
    }
}