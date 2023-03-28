using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class OrderService : IOrderService
{
    private QuickBiteContext _context { get; set; }
    private IUserService _userService { get; set; }
    private ICartService _cartService { get; set; }

    public OrderService(QuickBiteContext context, IUserService userService, ICartService cartService)
    {
        _context = context;
        _userService = userService;
        _cartService = cartService;
    }

    public async Task<List<Order>> QueryAllOrdersByUserId(int userId) =>
        await _context.Orders
            .Include(order => order.Dishes)
            .Where(order => order.UserId == userId)
            .ToListAsync();

    public async Task<Order> PlaceOrder(int userId, string address)
    {
        var user = await _userService.QueryUserById(userId);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }

        var cart = user.Cart;

        var order = new Order
        {
            Address = address,
            Dishes = cart.CartDishes,
            TotalPrice = cart.TotalPrice,
            UserId = userId
        };

        user.Orders.Add(order);
        await _cartService.EmptyCart(cart);

        await _context.SaveChangesAsync();

        return order;
    }
}