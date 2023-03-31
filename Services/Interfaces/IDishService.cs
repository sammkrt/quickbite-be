using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IDishService
{
    Task<Dish> QueryDishById(int id);
}