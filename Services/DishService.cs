using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class DishService : IDishService
{
    private QuickBiteContext _context { get; set; }

    public DishService(QuickBiteContext context)
    {
        _context = context;
    }

    public async Task<Dish> QueryDishById(int id)
    {
        var dishFromDb = await _context.Dishes.FirstOrDefaultAsync(dish => dish.Id == id);
        if (dishFromDb == null)
        {
            throw new ArgumentException("Dish not found.");
        }

        return dishFromDb;
    }

    public async Task<List<Dish>> GetAllDishes() 
        => await QueryAllDishes().ToListAsync();

    private IQueryable<Dish> QueryAllDishes()
        => _context.Dishes;
}