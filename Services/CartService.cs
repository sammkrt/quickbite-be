using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class CartService : ICartService
{
    private readonly QuickBiteContext _context;
    private readonly IDishService _DishService;
    private readonly IUserService _userService;
    private readonly IRestaurantService _restaurantService;
    private readonly ICartDishService _cartDishService;

    public CartService(QuickBiteContext context, IDishService dishService, IUserService userService,
        IRestaurantService restaurantService, ICartDishService cartDishService)
    {
        _context = context;
        _DishService = dishService;
        _userService = userService;
        _restaurantService = restaurantService;
        _cartDishService = cartDishService;
    }

    public async Task<Cart> QueryCartById(int id)
    {
        var cart = await _context.Carts.Include(cart => cart.CartDishes)
            .FirstOrDefaultAsync(cart => cart.Id == id);

        if (cart == null)
            throw new ArgumentException("Cart not found.");

        return cart;
    }

    public async Task<CartDish> AddDishToCart(int userId, AddDishToCartRequest request)
    {
        var cart = (await _userService.GetUserById(userId)).Cart;
        var dish = await _DishService.QueryDishById(request.DishId);

        InputValidator.ValidateIfNumericInputIsGreaterThan0(request.Quantity, "Quantity must be a positive number.");

        var cartDishFromDb = GetCartDishFromCart(cart, request.DishId);

        var newPrice = dish.Price * request.Quantity;
        
        if (cartDishFromDb == null)
        {
            var cartDish = new CartDish
            {
                DishId = request.DishId,
                Quantity = request.Quantity,
                RestaurantId = dish.RestaurantId,
                PricePerDish = dish.Price,
                TotalPrice = newPrice ,
                PictureUrl = dish.PictureUrl
            };

            cart.CartDishes.Add(cartDish);

            cart.TotalPrice += newPrice;

            await _context.SaveChangesAsync();
            return cartDish;
        }

        cartDishFromDb.Quantity += request.Quantity;
        
        cart.TotalPrice += newPrice;

        await _context.SaveChangesAsync();
        return cartDishFromDb;
    }

    private async Task RemoveDishFromCart(int userId, int dishId)
    {
        var cart = (await _userService.GetUserById(userId)).Cart;

        var cartDish = GetCartDishFromCart(cart, dishId);

        if (cartDish == null)
            throw new ArgumentException("Cart dish not found.");

        var dish = await _DishService.QueryDishById(dishId);
        cart.CartDishes.Remove(cartDish);

        cart.TotalPrice -= dish.Price * cartDish.Quantity;

        _cartDishService.RemoveCartDish(cartDish);
    }

    private static CartDish? GetCartDishFromCart(Cart cart, int dishId)
        => cart.CartDishes.FirstOrDefault(cartDish => cartDish.DishId == dishId);

    public async Task<CartDish> EditQuantityOfDishInCart(EditCartDishQuantityRequest request)
    {
        var cart = (await _userService.GetUserById(request.UserId)).Cart;
        var cartDish = GetCartDishFromCart(cart, request.DishId);
        
        if (cartDish == null)
            throw new ArgumentException("Cart dish not found.");

        InputValidator.ValidateIfNumericInputIsAtLeast0(request.Quantity, "Quantity must be at least 0.");

        if (request.Quantity == 0)
        {
            await RemoveDishFromCart(request.UserId, request.DishId);
        }
        else
        {
            var dish = await _DishService.QueryDishById(request.DishId);
            
            var oldPrice = dish.Price * cartDish.Quantity;
            var newPrice = dish.Price * request.Quantity;
            cart.TotalPrice = cart.TotalPrice - oldPrice + newPrice;
            
            cartDish.Quantity = request.Quantity;
        }

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