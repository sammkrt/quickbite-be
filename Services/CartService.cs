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

    public CartService(QuickBiteContext context, IDishService dishService,IUserService userService)
    {
        _context = context;
        _DishService = dishService;
        _userService = userService;
    }

    public Task<Cart?> QueryCartById(int id)
        => _context.Carts.Include(cart => cart.CartDishes)
            .FirstOrDefaultAsync(cart => cart.Id == id);

    public async Task<CartDish> AddDishToCart(int userId, AddDishToCartRequest request)
    {
        var user = await _userService.QueryUserById(userId);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }

        var cart = user.Cart;

        var dish = await _DishService.QueryDishById(request.DishId);

        if (dish == null)
        {
            throw new ArgumentException("Dish not found.");
        }

        var cartDishFromDb = cart.CartDishes.SingleOrDefault(cartDish => cartDish.DishId == request.DishId);

        if (cartDishFromDb == null)
        {
            var cartDish = new CartDish
            {
                DishId = request.DishId,
                Quantity = request.Quantity
            };

            cart.CartDishes.Add(cartDish);
        }
        else
        {
            cartDishFromDb.Quantity += request.Quantity;
        }

        cart.TotalPrice += dish.Price * request.Quantity;

        await _context.SaveChangesAsync();
        return cartDishFromDb;
    }

    public Task EmptyCart(Cart cart)
    {
        cart.CartDishes = new List<CartDish>();
        cart.TotalPrice = 0;
        return Task.CompletedTask;
    }
}