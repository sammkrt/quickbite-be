using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace QuickBiteBE.Models;

public class User
{
    public int Id { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public string Email { get; set; }
    [JsonIgnore] [Required] public string Password { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string PhoneNumber { get; set; }
    public Cart Cart { get; set; }
    public List<Order> Orders { get; set; }
}