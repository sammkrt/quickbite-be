namespace QuickBiteBE.Models;

public class Cart
{
    public int Id { get; set; }
    public List<CartDish> CartDishes { get; set; }
    public double TotalPrice { get; set; }
}