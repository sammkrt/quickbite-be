using QuickBiteBE.Dtos.Payments;
using QuickBiteBE.Services.Interfaces;
using Stripe;

namespace QuickBiteBE.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentIntentService _paymentIntentService;
        private readonly PaymentMethodService _paymentMethodService;
        private readonly IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration.GetConnectionString("StripeConnection");
            _paymentIntentService = new PaymentIntentService();
            _paymentMethodService = new PaymentMethodService();
        }

        public PaymentIntent CreatePaymentIntent(PaymentIntentCreateDto paymentIntentCreateDto)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = paymentIntentCreateDto.Amount,
                Currency = paymentIntentCreateDto.Currency,
            };

            var paymentIntent = _paymentIntentService.Create(options);

            return paymentIntent;
        }

        public PaymentMethod CreatePaymentMethod(PaymentMethodCreateDto paymentMethodCreateDto)
        {
            var options = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = paymentMethodCreateDto.CardNumber,
                    ExpMonth = paymentMethodCreateDto.ExpiryMonth,
                    ExpYear = paymentMethodCreateDto.ExpiryYear,
                    Cvc = paymentMethodCreateDto.Cvc,
                },
            };

            var paymentMethod = _paymentMethodService.Create(options);

            return paymentMethod;
        }
        
        public string CompletePayment(PaymentIntentCompleteDto paymentIntentCompleteDto)
    {
        if (string.IsNullOrEmpty(paymentIntentCompleteDto.PaymentIntentId))
        {
            return "Payment intent ID cannot be null or empty";
        }

        var paymentIntent = _paymentIntentService.Get(paymentIntentCompleteDto.PaymentIntentId);

        if (paymentIntent != null)
        {
            if (paymentIntent.Status == "requires_payment_method")
            {
                var paymentMethodOptions = new PaymentMethodCreateOptions
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions
                    {
                        Number = "4242424242424242",
                        ExpMonth = 12,
                        ExpYear = 2024,
                        Cvc = "123",
                    },
                };

                var paymentMethod = _paymentMethodService.Create(paymentMethodOptions);

                var paymentIntentOptions = new PaymentIntentConfirmOptions
                {
                    PaymentMethod = paymentMethod.Id,
                };

                var result = _paymentIntentService.Confirm(paymentIntent.Id, paymentIntentOptions);

                if (result.Status == "succeeded")
                {
                    return "Payment succeeded";
                }

                return "Payment failed";
            }

            if (paymentIntent.Status == "requires_confirmation")
            {
                var options = new PaymentIntentConfirmOptions();
                var result = _paymentIntentService.Confirm(paymentIntent.Id, options);

                if (result.Status == "succeeded")
                {
                    return "Payment succeeded";
                }

                return "Payment failed";
            }

            if (paymentIntent.Status == "succeeded")
            {
                return "Payment succeeded";
            }

            return $"Payment intent status is {paymentIntent.Status}";
        }

        return "Payment intent not found";
    }
    }
}