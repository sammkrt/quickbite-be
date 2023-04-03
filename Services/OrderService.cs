using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class OrderService : IOrderService
{
    private readonly QuickBiteContext _context;
    private readonly IUserService _userService;
    private readonly ICartService _cartService;

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

    public async Task<Order> PlaceOrder(PlaceOrderRequest request)
    {

        var user = await _userService.GetUserById(request.UserId);
        var cart = user.Cart;

        ThrowIfCartIsEmpty(cart);

        var order = new Order
        {
            Dishes = cart.CartDishes,
            TotalPrice = cart.TotalPrice,
            UserId = request.UserId
        };

        user.Orders.Add(order);
        await _cartService.EmptyCart(cart);
        await _context.SaveChangesAsync();

        return order;
    }

    private static void ThrowIfCartIsEmpty(Cart cart)
    {
        if (cart.CartDishes.Count == 0)
            throw new Exception("Cannot place an order if the cart is empty.");
    }
}