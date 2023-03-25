using QuickBiteBE.Data;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class UserService : IUserService
{
    private QuickBiteContext Context { get; set; }

    public UserService(QuickBiteContext context)
    {
        Context = context;
    }
}