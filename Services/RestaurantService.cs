using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Data;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class RestaurantService : IRestaurantService
{
    private QuickBiteContext _context { get; set; }

    public RestaurantService(QuickBiteContext context)
    {
        _context = context;
    }

    public async Task<List<Restaurant>> GetAllRestaurants()
        => await QueryAllRestaurants().ToListAsync();

    public Task<Restaurant> GetRestaurantById(int id)
        => _context.Restaurants.FirstAsync(restaurant => restaurant.Id == id);

    public async Task<List<Restaurant>> FilterRestaurantsBySearchBar(string input)
    {
        var restaurants =
            (from restaurant in await QueryAllRestaurants().ToListAsync()
                from dish in restaurant.Dishes
                where dish.Name == input
                select restaurant)
            .ToList();
        return restaurants;
    }

    private IQueryable<Restaurant> QueryAllRestaurants()
        => _context.Restaurants;
}