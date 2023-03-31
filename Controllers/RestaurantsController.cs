using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantsController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants() =>
        await _restaurantService.GetAllRestaurants();

    [HttpGet]
    [Route("search")]
    public async Task<ActionResult<List<Restaurant>>> FilterRestaurantsFromSearch(string input)
        => await _restaurantService.FilterRestaurantsBySearchBar(input);

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        => await _restaurantService.QueryRestaurantById(id);

    [HttpPost]
    public async Task<ActionResult<Restaurant>> CreateRestaurant([FromForm] AddRestaurantRequest request,
        IFormFile image)
        => await _restaurantService.CreateRestaurant(request, image);
}