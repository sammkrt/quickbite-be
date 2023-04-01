using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickBiteBE.Models;

public class CartDish
{
    public int Id { get; set; }
    [Required] public int DishId { get; set; }
    [Required] public Dish Dish { get; set; }
    [Required] public int Quantity { get; set; }

    public int RestaurantId { get; set; } // THIS
    [Required]public string PictureUrl { get; set; }
    [Required] public double PricePerDish { get; set; }
    [Required] public double TotalPrice { get; set; }
    
}