namespace QuickBiteBE.Models.Requests;

public class EditCartDishQuantityRequest
{
    public int UserId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
}