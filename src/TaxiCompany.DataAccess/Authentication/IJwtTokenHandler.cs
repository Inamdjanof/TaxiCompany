using System.IdentityModel.Tokens.Jwt;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(User user);
    string GenerateRefreshToken();
}