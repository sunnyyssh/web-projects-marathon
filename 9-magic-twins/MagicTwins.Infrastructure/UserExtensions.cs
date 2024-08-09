using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MagicTwins.Infrastructure;

public static class UserExtensions
{
    public static IReadOnlyList<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Name, user.Name),
        };

        if (user.Roles is not null)
        {
            result.Add(new Claim(ClaimNames.Role, string.Join(',', user.Roles)));
        }

        return result;
    }

    public static User ExtractUser(this IEnumerable<Claim> claims)
    {
        var claimsDict = claims.ToDictionary(c => c.Type, c => c.Value);
        
        if (!claimsDict.TryGetValue(ClaimNames.JwtSub, out string? sub))
        {
            throw new InvalidOperationException("No sub claim provided");
        }

        if (!claimsDict.TryGetValue(JwtRegisteredClaimNames.Name, out string? name))
        {
            throw new InvalidOperationException("No name claim provided");
        }

        claimsDict.TryGetValue(ClaimNames.JwtRole, out string? roles);

        return new User(sub, name, roles?.Split());
    }

    public static bool IsInRole(this User user, string roleName) => user.Roles?.Contains(roleName) ?? false;
}