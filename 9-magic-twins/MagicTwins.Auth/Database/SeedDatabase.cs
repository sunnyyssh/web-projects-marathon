using MagicTwins.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace MagicTwins.Auth.Database;

public static class SeedDatabase
{
    public static void EnsureMainRolesCreated(this IServiceProvider services)
    {
        var roleManager = services.CreateScope().ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();
        
        EnsureAsync(roleManager).ConfigureAwait(false)
            .GetAwaiter().GetResult();
        return;

        static async Task EnsureAsync(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync(UserRoles.Admin) is null)
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
        }
    }
}