using QuickBiteBE.Dtos.Payments;
using Stripe;

namespace QuickBiteBE.Services.Interfaces;

public interface IPaymentService
{
    PaymentIntent CreatePaymentIntent(PaymentIntentCreateDto paymentIntentCreateDto);
    PaymentMethod CreatePaymentMethod(PaymentMethodCreateDto paymentMethodCreateDto);
    string CompletePayment(PaymentIntentCompleteDto paymentIntentCompleteDto);

}