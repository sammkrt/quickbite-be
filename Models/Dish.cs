using System.ComponentModel.DataAnnotations;

namespace QuickBiteBE.Models;

public class Dish
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [Required] public int CategoryId { get; set; }
    [Required] public double Price { get; set; }
    [Required] public string PictureUrl { get; set; }
    public int RestaurantId { get; set; }
}