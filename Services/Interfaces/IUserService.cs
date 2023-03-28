using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IUserService
{
    Task<User?> QueryUserById(int id);
}