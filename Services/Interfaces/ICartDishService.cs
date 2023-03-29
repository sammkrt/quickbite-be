using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface ICartDishService
{
    void RemoveCartDish(CartDish cartDish);
    Task<CartDish> FindCartDish(int cartDishId);
}