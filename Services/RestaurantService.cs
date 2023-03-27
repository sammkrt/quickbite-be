using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Controllers;
using QuickBiteBE.Data;
using QuickBiteBE.Dtos;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class RestaurantService : IRestaurantService
{
    private QuickBiteContext _context { get; set; }
    private readonly BlobServiceClient _blobServiceClient;
    
    private IBlobService BlobService { get; set; }

    public RestaurantService(QuickBiteContext context, IBlobService blobService, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _blobServiceClient = new BlobServiceClient(connectionString);
        _context = context;
        BlobService = blobService;
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

    // public async Task<Restaurant> CreateRestaurant(AddRestaurantRequest request, IFormFile file)
    // {
    //     var restaurant = new Restaurant
    //     {
    //         Name = request.Name,
    //         Description = request.Description,
    //         Location = request.Location,
    //         PhoneNumber = request.PhoneNumber,
    //         Email = request.Email,
    //         MainPictureUrl = await BlobService.UploadFileV2(file),
    //         DeliveryCost = request.DeliveryCost,
    //         Dishes = new List<Dish>()
    //     };
    //     _context.Restaurants.Add(restaurant);
    //     await _context.SaveChangesAsync();
    //     return restaurant;
    // }
    
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

  
        if (image != null && image.Length > 0)
        {
            var containerName = "quickbitecontainer";
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var fileName = $"{restaurant.Name}-{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}{Path.GetExtension(image.FileName)}";
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(image.OpenReadStream(), true);

            restaurant.MainPictureUrl = blobClient.Uri.ToString();
        }

        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
        return restaurant;
    }
}