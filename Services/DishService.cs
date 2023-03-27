using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services
{
    public class DishService : IDishService
    {
        private readonly QuickBiteContext _context;

        public DishService(QuickBiteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishesByCategoryIdAsync(int categoryId)
        {
            return await _context.Dishes.Where(d => d.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int dishId)
        {
            return await _context.Dishes.FindAsync(dishId);
        }

        public async Task<Dish> CreateDishAsync(Dish dish)
        {
            var category = await _context.Categories.FindAsync(dish.CategoryId);

            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }

            var newDish = new Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                CategoryId = dish.CategoryId,
                Price = dish.Price,
                RestaurantId = dish.RestaurantId
            };

            await _context.Dishes.AddAsync(newDish);
            await _context.SaveChangesAsync();

            return newDish;
        }

        public async Task<Dish> UpdateDishAsync(int dishId, Dish dish)
        {
            var existingDish = await GetDishByIdAsync(dishId);

            if (existingDish == null)
            {
                throw new ArgumentException("Dish not found.");
            }

            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.CategoryId = dish.CategoryId;
            existingDish.Price = dish.Price;
            existingDish.RestaurantId = dish.RestaurantId;

            await _context.SaveChangesAsync();

            return existingDish;
        }

        public async Task DeleteDishAsync(int dishId)
        {
            var dish = await GetDishByIdAsync(dishId);

            if (dish == null)
            {
                throw new ArgumentException("Dish not found.");
            }

            _context.Dishes.Remove(dish);

            await _context.SaveChangesAsync();
        }
    }
}
