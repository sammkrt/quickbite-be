using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;

namespace QuickBiteBE.Data;

public class UserRepository : IUserRepository
{
    private readonly QuickBiteContext _context;

    public UserRepository(QuickBiteContext context)
    {
        _context = context;
    }
    public User Create(User user)
    {
        _context.Users.Add(user);
        user.Id = _context.SaveChanges();
        return user;
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    } 
    public User GetById(int id)
    {
        return _context.Users
            .Include(user => user.Cart)
            .Include(user => user.Cart.CartDishes)
            .Include(user => user.Orders)
            .FirstOrDefault(u => u.Id == id);
    }
}