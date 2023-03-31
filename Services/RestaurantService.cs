using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Controllers;
using QuickBiteBE.Data;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class RestaurantService : IRestaurantService
{
    private readonly QuickBiteContext _context;
    private readonly IBlobService _blobService;

    public RestaurantService(QuickBiteContext context, IBlobService blobService)
    {
        _context = context;
        _blobService = blobService;
    }

    public async Task<List<Restaurant>> GetAllRestaurants()
        => await QueryAllRestaurants().ToListAsync();

    public async Task<Restaurant> QueryRestaurantById(int id)
    {
        var restaurant = await _context.Restaurants.Include(r => r.Dishes)
            .FirstOrDefaultAsync(restaurant => restaurant.Id == id);

        if (restaurant == null)
            throw new ArgumentException("Restaurant not found.");

        return restaurant;
    }

    public async Task<double> GetRestaurantDeliveryCost(int restaurantId) 
        => (await QueryRestaurantById(restaurantId)).DeliveryCost;

    public async Task<List<Restaurant>> FilterRestaurantsBySearchBar(string input)
    {
        var restaurants =
            (from restaurant in await QueryAllRestaurants().ToListAsync()
                from dish in restaurant.Dishes
                where dish.Name.ToLower().Contains(input.ToLower())
                select restaurant)
            .ToList();
        return restaurants;
    }

    private IQueryable<Restaurant> QueryAllRestaurants()
        => _context.Restaurants.Include(r => r.Dishes);

    public async Task<Restaurant> CreateRestaurant(AddRestaurantRequest request, IFormFile image)
    {
        var restaurant = new Restaurant
        {
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            DeliveryCost = request.DeliveryCost,
            Dishes = new List<Dish>()
        };

        if (!IsImageValid(image))
            throw new ArgumentException("Invalid image format. Only PNG and JPG/JPEG are allowed.");

        restaurant.MainPictureUrl = await _blobService.UploadFile(image);

        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
        return restaurant;
    }
    
    private static bool IsImageValid(IFormFile file)
    {
        var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        return file is { Length: > 0 } && allowedExtensions.Contains(fileExtension);
    }
}