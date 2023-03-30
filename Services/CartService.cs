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

        var cartDishFromDb = GetCartDishFromCart(cart, request.DishId);

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

        var cartDish = GetCartDishFromCart(cart, dishId);

        if (cartDish == null)
        {
            throw new ArgumentException("Cart dish not found.");
        }

        var dish = await _DishService.QueryDishById(dishId);
        cart.CartDishes.Remove(cartDish);

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

        cart.TotalPrice -= dish.Price * cartDish.Quantity;

        _cartDishService.RemoveCartDish(cartDish);

        await _context.SaveChangesAsync();
    }

    private static CartDish? GetCartDishFromCart(Cart cart, int dishId)
        => cart.CartDishes.FirstOrDefault(cartDish => cartDish.DishId == dishId);

    private static void ThrowExceptionIfCartDishIsNull(CartDish? cartDish)
    {
        if (cartDish == null)
        {
            throw new ArgumentException("Cart dish not found.");
        }
    }

    public async Task<CartDish> EditQuantityOfDishInCart(EditCartDishQuantityRequest request) // TODO 
    {
        var cart = (await _userService.QueryUserById(request.UserId)).Cart;
        var cartDish = GetCartDishFromCart(cart, request.DishId);

        if (cartDish == null)
        {
            throw new ArgumentException("Cart dish not found.");
            // ThrowExceptionIfCartDishIsNull(cartDish); // These two are the same but cleaner code. (not sure if it would work tho)
        }

        if (request.Quantity == 0)
        {
            await RemoveDishFromCart(request.UserId, request.DishId);
        }

        var dish = await _DishService.QueryDishById(request.DishId);

        var previousCartDishPrice = dish.Price * cartDish.Quantity;
        var newCartDishPrice = dish.Price * request.Quantity;
        cart.TotalPrice -= newCartDishPrice;

        cartDish.Quantity = request.Quantity;

        await _context.SaveChangesAsync();
        return cartDish;
    }

    public Task EmptyCart(Cart cart)
    {
        cart.CartDishes = new List<CartDish>();
        cart.TotalPrice = 0;
        return Task.CompletedTask;
    }
}