using Microsoft.AspNetCore.Identity;

namespace MagicTwins.Auth.Model;

public interface IJwtProvider
{
    JwtToken Create(IdentityUser user);
}