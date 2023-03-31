namespace QuickBiteBE.Models.Requests;

public class PlaceOrderRequest
{
    public int UserId { get; set; }
    public string Address { get; set; }
}