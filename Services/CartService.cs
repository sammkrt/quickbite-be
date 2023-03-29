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
    private ICartDishService _cartDishService { get; set; }

    public CartService(QuickBiteContext context, IDishService dishService, IUserService userService,
        IRestaurantService restaurantService, ICartDishService cartDishService)
    {
        _context = context;
        _DishService = dishService;
        _userService = userService;
        _restaurantService = restaurantService;
        _cartDishService = cartDishService;
    }

    public Task<Cart?> QueryCartById(int id)
        => _context.Carts.Include(cart => cart.CartDishes)
            .FirstOrDefaultAsync(cart => cart.Id == id);

    public async Task<CartDish> AddDishToCart(int userId, AddDishToCartRequest request)
    {
        var cart = (await _userService.QueryUserById(userId)).Cart;
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

        cart.TotalPrice += dish.Price * request.Quantity;
        
        // var restaurantId = dish.RestaurantId;
        // if (CheckIfCartContainsDishesFromRestaurant(cart, restaurantId))
        // {
        //     cart.TotalPrice += dish.Price * request.Quantity;
        // }

        // else
        // {
        //     var deliveryCost = await _restaurantService.GetRestaurantDeliveryCost(restaurantId);
        //     cart.TotalPrice += dish.Price * request.Quantity + deliveryCost;
        // }

        await _context.SaveChangesAsync();
        return cartDishFromDb; // something is not getting saved in this one.
    }

    // private static bool CheckIfCartContainsDishesFromRestaurant(Cart cart, int restaurantId) // Always returns true
    //     => cart.CartDishes.Any(cartDish => cartDish.RestaurantId == restaurantId);

    public async Task RemoveDishFromCart(int userId, int dishId)
    {
        var cart = (await _userService.QueryUserById(userId)).Cart;

        var cartDishFromDb = cart.CartDishes.SingleOrDefault(cartDish => cartDish.DishId == dishId);
        if (cartDishFromDb == null)
        {
            throw new ArgumentException("Cart dish not found -------------------------.");
        }

        var dish = await _DishService.QueryDishById(dishId);

        cart.CartDishes.Remove(cartDishFromDb);

        // var restaurantId = dish.RestaurantId;
        // if (CheckIfCartContainsDishesFromRestaurant(cart, restaurantId))
        // {
        //     cart.TotalPrice -= dish.Price * cartDishFromDb.Quantity;
        // }
        // else
        // {
        //     var deliveryCost = await _restaurantService.GetRestaurantDeliveryCost(restaurantId);
        //     cart.TotalPrice -= dish.Price * cartDishFromDb.Quantity + deliveryCost;
        // }

        cart.TotalPrice -= dish.Price * cartDishFromDb.Quantity;


        _cartDishService.RemoveCartDish(cartDishFromDb);

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