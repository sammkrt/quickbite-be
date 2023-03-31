namespace QuickBiteBE.Dtos.Payments;

public class PaymentIntentCreateDto
{
    public int Amount { get; set; }
    public string Currency { get; set; }
}