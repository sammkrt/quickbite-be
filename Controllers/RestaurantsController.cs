using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Dtos;
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
        
        await RestaurantService.GetAllRestaurants();
    
    // Check if Empty. If empty, return BadRequest

    [HttpGet]
    [Route("search")]
    public async Task<ActionResult<List<Restaurant>>> FilterRestaurantsFromSearch(string input)
        => await RestaurantService.FilterRestaurantsBySearchBar(input);

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
    {
        var query = await RestaurantService.QueryRestaurantById(id);
        
        if (id == null || query == null)
            return NotFound();

        return query;
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> CreateRestaurant([FromForm]AddRestaurantRequest request,  IFormFile image)
    {
        if (image != null && image.Length > 0 && !IsImageValid(image))
        {
            return BadRequest("Invalid image format. Only PNG and JPG/JPEG are allowed.");
        }

        var restaurant = await RestaurantService.CreateRestaurant(request, image);

        return Ok(restaurant);
    }

    private bool IsImageValid(IFormFile file)
    {
        var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        return file != null && file.Length > 0 && allowedExtensions.Contains(fileExtension);
    }
}