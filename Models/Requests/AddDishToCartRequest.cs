using Microsoft.Build.Framework;

namespace QuickBiteBE.Models.Requests;

public class AddDishToCartRequest
{
    [Required] public int DishId { get; set; }
    [Required] public int Quantity { get; set; }
}