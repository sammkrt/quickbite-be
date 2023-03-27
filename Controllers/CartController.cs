using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Services;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Cart>> CreateCartAsync()
    {
        var cart = await _cartService.CreateCartAsync();

        return Ok(cart);
    }

    [HttpGet("{cartId}")]
    public async Task<ActionResult<Cart>> GetCartByIdAsync(int cartId)
    {
        var cart = await _cartService.GetCartByIdAsync(cartId);

        if (cart == null)
        {
            return NotFound();
        }

        return Ok(cart);
    }

    [HttpPost("{cartId}/dishes")]
    public async Task<ActionResult<CartDish>> AddDishToCartAsync(int cartId, [FromBody] AddDishToCartRequest request)
    {
        var cartDish = await _cartService.AddDishToCartAsync(cartId, request.DishId, request.Quantity);

        return Ok(cartDish);
    }

    [HttpDelete("{cartId}/dishes/{cartDishId}")]
    public async Task<ActionResult> RemoveDishFromCartAsync(int cartId, int cartDishId)
    {
        await _cartService.RemoveDishFromCartAsync(cartId, cartDishId);

        return Ok();
    }
}

public class AddDishToCartRequest
{
    public int DishId { get; set; }
    public int Quantity { get; set; }
}
