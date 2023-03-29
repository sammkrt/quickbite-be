using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class CartService : ICartService
{
    private QuickBiteContext _context { get; set; }
    private IDishService _DishService { get; set; }
    private IUserService _userService { get; set; }
    private IRestaurantService _restaurantService { get; set; }

    public CartService(QuickBiteContext context, IDishService dishService, IUserService userService,
        IRestaurantService restaurantService)
    {
        _context = context;
        _DishService = dishService;
        _userService = userService;
        _restaurantService = restaurantService;
    }

    public Task<Cart?> QueryCartById(int id)
        => _context.Carts.Include(cart => cart.CartDishes)
            .FirstOrDefaultAsync(cart => cart.Id == id);

    public async Task<CartDish> AddDishToCart(int userId, AddDishToCartRequest request)
    {
        var user = await _userService.QueryUserById(userId);
        var cart = user.Cart;
        var dish = await _DishService.QueryDishById(request.DishId);
        var cartDishFromDb = cart.CartDishes.SingleOrDefault(cartDish => cartDish.DishId == request.DishId);

        if (cartDishFromDb == null)
        {
            var cartDish = new CartDish
            {
                DishId = request.DishId,
                Quantity = request.Quantity,
                RestaurantId = dish.RestaurantId // THIS
            };

            cart.CartDishes.Add(cartDish);
        }
        else
        {
            cartDishFromDb.Quantity += request.Quantity;
        }

        var restaurantId = dish.RestaurantId;
        if (!CheckIfCartContainsDishesFromRestaurant(cart, restaurantId))
        {
            var restaurant = await _restaurantService.GetRestaurantById(restaurantId);
            var deliveryCost = restaurant.DeliveryCost;
            cart.TotalPrice += dish.Price * request.Quantity + deliveryCost;
        }
        else
        {
            cart.TotalPrice += dish.Price * request.Quantity;
        }

        await _context.SaveChangesAsync();
        return cartDishFromDb;
    }

    private static bool CheckIfCartContainsDishesFromRestaurant(Cart cart, int restaurantId) // TODO
        => cart.CartDishes.Exists(dish => dish.RestaurantId == restaurantId);

    public async Task RemoveDishFromCart(int userId, int dishId) // TODO 
    {
        await _context.SaveChangesAsync();
    }

    public async Task EditQuantityOfDishInCart(int userId, int dishId) // TODO 
    {
        await _context.SaveChangesAsync();
    }

    public Task EmptyCart(Cart cart)
    {
        cart.CartDishes = new List<CartDish>();
        cart.TotalPrice = 0;
        return Task.CompletedTask;
    }
}