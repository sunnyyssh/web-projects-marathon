using Microsoft.AspNetCore.Identity;
using SimpleShop.Constants;

namespace SimpleShop.Database;

public static class SeedDatabase
{
    public static void EnsureMainRolesExist(this IServiceProvider services)
    {
        var roleManager = services.CreateScope().ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        EnsureAsync(roleManager).GetAwaiter().GetResult();
        return;

        static async Task EnsureAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { RolesConstants.Admin, RolesConstants.Supplier, RolesConstants.Customer };
            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                {
                    continue;
                }
                
                var result = await roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Can't create {role} role");
                }
            }
        }
    }
}