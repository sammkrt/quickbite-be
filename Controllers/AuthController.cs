using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Data;
using QuickBiteBE.Helpers;
using QuickBiteBE.Models;
using QuickBiteBE.Models.Requests;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("[controller]")]
public partial class AuthController : Controller
{
    private readonly IUserRepository _repository;
    private readonly IJWTService _jwtService;

    [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
    private static partial Regex MailPattern();
    public AuthController(IUserRepository repository, IJWTService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        if (!MailPattern().IsMatch(request.Email))
            throw new ArgumentException("Invalid mail.");
  

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Cart = new Cart(),
            Orders = new List<Order>()
        };
        return Created("success", _repository.Create(user));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _repository.GetByEmail(request.Email);
        if (user == null)
        {
            return BadRequest(new { message = "Invalid Credentials" });
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return BadRequest(new { message = "Invalid Credentials" });
        }

        var jwt = _jwtService.Generate(user.Id);
        Response.Cookies.Append("jwt", jwt, new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Lax
        });
        return Ok(new
        {
            message = "success",
            jwt
        });
    }

    [HttpGet("user")]
    public IActionResult User()
    {
        try
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);
            var userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            return Ok(user);
        }
        catch (Exception _)
        {
            return Unauthorized();
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");

        return Ok(new
        {
            message = "success"
        });
    }
}