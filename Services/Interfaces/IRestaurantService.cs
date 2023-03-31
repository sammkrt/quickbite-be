using QuickBiteBE.Controllers;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;

namespace QuickBiteBE.Services.Interfaces;

public interface IRestaurantService
{
    Task<List<Restaurant>> GetAllRestaurants();
    Task<Restaurant> QueryRestaurantById(int id);
    Task<List<Restaurant>> FilterRestaurantsBySearchBar(string input);
    Task<Restaurant> CreateRestaurant(AddRestaurantRequest request, IFormFile file);
    Task<double> GetRestaurantDeliveryCost(int restaurantId);
}