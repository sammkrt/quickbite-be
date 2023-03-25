using System.ComponentModel.DataAnnotations;

namespace QuickBiteBE.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Categoy { get; set; }
}