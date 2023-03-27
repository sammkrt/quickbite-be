using System.ComponentModel.DataAnnotations;

namespace QuickBiteBE.Models;

public class Order
{
    public int Id { get; set; }
    [Required] public List<CartDish> Dishes { get; set; }
    [Required] public string Address { get; set; }
    public double TotalPrice { get; set; }
}