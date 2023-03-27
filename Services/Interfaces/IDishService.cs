using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IDishService
{
    Task<IEnumerable<Dish>> GetAllDishesAsync();
    Task<IEnumerable<Dish>> GetDishesByCategoryIdAsync(int categoryId);
    Task<Dish> GetDishByIdAsync(int dishId);
    Task<Dish> CreateDishAsync(Dish dish);
    Task<Dish> UpdateDishAsync(int dishId, Dish dish);
    Task DeleteDishAsync(int dishId);
}