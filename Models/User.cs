using System.ComponentModel.DataAnnotations;

namespace QuickBiteBE.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    

    // [Required] public Role Role { get; set; }
    // [Required] public string FirstName { get; set; }
    // [Required] public string LastName { get; set; }
    // [Required] public string Address { get; set; }
    // [Required] public string PhoneNumber { get; set; }
    // public Cart Cart { get; set; }
    // public List<Order> Orders { get; set; }
}