using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BooksLibrary;

public sealed class IdentityOptionsSetup : IConfigureOptions<IdentityOptions>
{
    public void Configure(IdentityOptions options)
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;

        options.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz";
    }
}