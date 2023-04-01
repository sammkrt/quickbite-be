using System.ComponentModel.DataAnnotations;

namespace QuickBiteBE.Models;

public class CartDish
{
    public int Id { get; set; }
    [Required] public int DishId { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public int RestaurantId { get; set; } // THIS
    [Required] public double PricePerDish { get; set; }
    [Required] public double TotalPrice { get; set; }
}