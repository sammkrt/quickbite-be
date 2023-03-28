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

    public CartService(QuickBiteContext context, IDishService dishService)
    {
        _context = context;
        _DishService = dishService;
    }

    public Task<Cart?> QueryCartById(int id)
        => _context.Carts.Include(cart => cart.CartDishes)
            .FirstOrDefaultAsync(cart => cart.Id == id);

    public async Task<CartDish> AddDishToCart(int cartId, AddDishToCartRequest request)
    {
        var cart = await QueryCartById(cartId);

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

    public async void setTotalPrice(Cart cart)
    {
        
    }
}

public interface ICartService
{
    Task<Cart?> QueryCartById(int id);
    Task<CartDish> AddDishToCart(int cartId, AddDishToCartRequest request);
}