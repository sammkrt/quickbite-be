using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PlaceOrder(PlaceOrderRequest request) 
        => await _orderService.PlaceOrder(request);

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrdersByUserId(int userId)
        => await _orderService.QueryAllOrdersByUserId(userId);
}