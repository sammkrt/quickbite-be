using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class CartDishService : ICartDishService
{
    private readonly QuickBiteContext _context;

    public CartDishService(QuickBiteContext context)
    {
        _context = context;
    }

    public void RemoveCartDish(CartDish cartDish) => _context.CartDishes.Remove(cartDish);

    public async Task<CartDish> FindCartDish(int cartDishId)
    {
        var cartDishFromDb = await _context.CartDishes.FirstOrDefaultAsync(cartDish => cartDish.Id == cartDishId);
        
        if (cartDishFromDb == null)
            throw new ArgumentException("Cart dish not found.");

        return cartDishFromDb;
    }
}