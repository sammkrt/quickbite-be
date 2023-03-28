using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IDishService
{
    Task<List<Dish>> GetAllDishes();
    Task<Dish?> QueryDishById(int id);
}