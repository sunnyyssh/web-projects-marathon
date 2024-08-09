using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MagicTwins.Auth.Model;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtSecurityTokenHandler _jwtTokenHandler;
    
    private readonly JwtOptions _options;
    
    public JwtProvider(IOptions<JwtOptions> options, JwtSecurityTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
        _options = options.Value;
    }
    
    public JwtToken Create(IdentityUser user)
    {
        var claims = ResolveClaims(user);

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.Now.Add(_options.ExpirationPeriod),
            signingCredentials);

        return _jwtTokenHandler.WriteToken(token);
    }

    private Claim[] ResolveClaims(IdentityUser user)
    {
        return new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName!)
        };
    }
}