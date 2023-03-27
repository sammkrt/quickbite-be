using QuickBiteBE.Controllers;
using QuickBiteBE.Dtos;
using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IRestaurantService
{
    Task<List<Restaurant>> GetAllRestaurants();
    Task<Restaurant> GetRestaurantById(int id);
    Task<List<Restaurant>> FilterRestaurantsBySearchBar(string input);
    Task<Restaurant> CreateRestaurant(AddRestaurantRequest request, IFormFile file);
}