using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;

namespace QuickBiteBE.Services.Interfaces;

public interface IOrderService
{
    Task<Order> PlaceOrder(PlaceOrderRequest request);
    Task<List<Order>> QueryAllOrdersByUserId(int userId);
}