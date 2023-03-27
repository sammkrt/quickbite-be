using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class CartService : ICartService
{
    private QuickBiteContext _context { get; set; }

        public CartService(QuickBiteContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateCartAsync()
        {
            var cart = new Cart();
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<Cart> GetCartByIdAsync(int cartId)
        {
            return await _context.Carts
                .Include(c => c.CartDishes)
                .SingleOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task<CartDish> AddDishToCartAsync(int cartId, int dishId, int quantity)
        {
            var cart = await GetCartByIdAsync(cartId);
            var dish = await _context.Dishes.FindAsync(dishId);

            if (dish == null)
            {
                throw new ArgumentException("Dish not found.");
            }

            var cartDish = cart.CartDishes.SingleOrDefault(cd => cd.Dish.Id == dishId);

            if (cartDish == null)
            {
                cartDish = new CartDish { Dish = dish, Quantity = quantity };
                cart.CartDishes.Add(cartDish);
            }
            else
            {
                cartDish.Quantity += quantity;
            }

            cart.TotalPrice += dish.Price * quantity;

            await _context.SaveChangesAsync();

            return cartDish;
        }

        public async Task RemoveDishFromCartAsync(int cartId, int cartDishId)
        {
            var cart = await GetCartByIdAsync(cartId);
            var cartDish = cart.CartDishes.SingleOrDefault(cd => cd.Id == cartDishId);

            if (cartDish == null)
            {
                throw new ArgumentException("Cart dish not found.");
            }

            cart.TotalPrice -= cartDish.Dish.Price * cartDish.Quantity;

            _context.CartDishes.Remove(cartDish);

            await _context.SaveChangesAsync();
        }
    }
