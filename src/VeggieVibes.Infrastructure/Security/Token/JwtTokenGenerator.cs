using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Security.Tokens;

namespace VeggieVibes.Infrastructure.Security.Token;
public class JwtTokenGenerator : IAccessTokenGenerator
{
    private readonly uint _expirationTimeInMinutes;
    private readonly string _signingKey;

    public JwtTokenGenerator(uint expirationTimeInMinutes, string signingKey)
    {
        _expirationTimeInMinutes = expirationTimeInMinutes;
        _signingKey = signingKey;
    }
    public string Generate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeInMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var  securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);
        return new SymmetricSecurityKey(key);
    }
}

