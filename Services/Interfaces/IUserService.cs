using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IUserService
{
    Task<User> GetUserById(int id);
}