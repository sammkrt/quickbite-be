using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class DishService : IDishService
{
    private readonly QuickBiteContext _context;

    public DishService(QuickBiteContext context)
    {
        _context = context;
    }

    public async Task<Dish> QueryDishById(int id)
    {
        var dishFromDb = await QueryAllDishes().FirstOrDefaultAsync(dish => dish.Id == id);
        
        if (dishFromDb == null)
            throw new ArgumentException("Dish not found.");

        return dishFromDb;
    }

    private IQueryable<Dish> QueryAllDishes()
        => _context.Dishes;
}