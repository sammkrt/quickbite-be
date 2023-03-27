using QuickBiteBE.Models;

namespace QuickBiteBE.Data;

public interface IUserRepository
{
    User Create(User user);
    User GetByEmail(string email);
    User GetById(int Id);
}