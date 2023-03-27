using System.ComponentModel.DataAnnotations;
using QuickBiteBE.Models;

namespace QuickBiteBE.Controllers;

public class AddRestaurantRequest
{
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [Required] public string Location { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string Email { get; set; }
    [Required] public double DeliveryCost { get; set; }
    [Required] public string MainPictureUrl { get; set; }
}