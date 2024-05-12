using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Infrastracture;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;
    

    public string GenerateToken(User user)
    {
        var claims = new[] { new Claim("userId", user.Id.ToString()) };

        var secretKey = "profitprofitprofitprofitprofitprofitprofitprofitprofitprofitprofitprofitprofitprofitprofit";
        var expiresHours = 100;
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(expiresHours)
        );
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        
        return tokenValue;
    }
}

