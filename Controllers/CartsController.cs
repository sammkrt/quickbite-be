using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;
using QuickBiteBE.Services;

namespace QuickBiteBE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private ICartService CartService { get; set; }

    public CartsController(ICartService cartService)
    {
        CartService = cartService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Cart>> GetCartById(int id)
    {
        var query = await CartService.QueryCartById(id);

        if (id == null || query == null)
            return NotFound();

        return query;
    }

    [HttpPost]
    public async Task<ActionResult<CartDish>> AddDishToCart(int cartId, [FromBody] AddDishToCartRequest request)
        => await CartService.AddDishToCart(cartId, request);
}

// delete dish from cart
// 