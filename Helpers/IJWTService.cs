using System.IdentityModel.Tokens.Jwt;

namespace QuickBiteBE.Helpers;

public interface IJWTService
{
    string Generate(int id);
    JwtSecurityToken Verify(string jwt);
}