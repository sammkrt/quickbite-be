using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Dtos.Payments;
using QuickBiteBE.Services.Interfaces;
using Stripe;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : Controller
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    [HttpPost]
    public IActionResult CreatePaymentIntent([FromBody] PaymentIntentCreateDto paymentIntentCreateDto)
    {
        
        var paymentIntent = _paymentService.CreatePaymentIntent(paymentIntentCreateDto);

        return Ok(paymentIntent);
    }


    [HttpPost]
    [Route("paymentmethod")]
    public IActionResult CreatePaymentMethod([FromBody] PaymentMethodCreateDto paymentMethodCreateDto)
    {
        var paymentMethod = _paymentService.CreatePaymentMethod(paymentMethodCreateDto);

        return Ok(paymentMethod);
    }
    
    [HttpPost]
    [Route("complete")]
    public IActionResult CompletePayment([FromBody] PaymentIntentCompleteDto paymentIntentCompleteDto)
    {
        var result = _paymentService.CompletePayment(paymentIntentCompleteDto);

        if (result == "Payment succeeded")
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}



