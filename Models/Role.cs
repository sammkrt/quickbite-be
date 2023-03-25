using System.ComponentModel.DataAnnotations;

namespace QuickBiteBE.Models;

public class Role
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Type { get; set; }
}