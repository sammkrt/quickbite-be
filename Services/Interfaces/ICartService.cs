using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;

namespace QuickBiteBE.Services.Interfaces;

public interface ICartService
{
    Task<Cart?> QueryCartById(int id);
    Task<CartDish> AddDishToCart(int userId, AddDishToCartRequest request);
    Task EmptyCart(Cart cart);
    Task RemoveDishFromCart(int userId, int dishId);
    Task<CartDish> EditQuantityOfDishInCart(EditCartDishQuantityRequest request);
}