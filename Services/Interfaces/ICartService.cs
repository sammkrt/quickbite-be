using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface ICartService
{
    Task<Cart> CreateCartAsync();
    Task<Cart> GetCartByIdAsync(int cartId);
    Task<CartDish> AddDishToCartAsync(int cartId, int dishId, int quantity);
    Task RemoveDishFromCartAsync(int cartId, int cartDishId);
    
}