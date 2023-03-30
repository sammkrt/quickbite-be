using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private ICartService _cartService { get; set; }

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Cart>> GetCartById(int id)
    {
        var query = await _cartService.QueryCartById(id);

        if (query == null)
            return NotFound();

        return query;
    }

    [HttpPost]
    public async Task<ActionResult<CartDish>> AddDishToCart(int userId, [FromBody] AddDishToCartRequest request)
        => await _cartService.AddDishToCart(userId, request);

    [HttpPatch]
    public async Task<ActionResult<CartDish>> EditQuantityOfDishInCart([FromBody] EditCartDishQuantityRequest request)
        => await _cartService.EditQuantityOfDishInCart(request);
}