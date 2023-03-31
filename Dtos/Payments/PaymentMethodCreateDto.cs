namespace QuickBiteBE.Dtos.Payments;

public class PaymentMethodCreateDto
{
    public string CardNumber { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string Cvc { get; set; }
}