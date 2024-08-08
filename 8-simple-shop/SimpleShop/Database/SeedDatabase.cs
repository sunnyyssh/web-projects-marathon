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

    public static void EnsureAdminUserExists(this IServiceProvider services)
    {
        using var serviceScope = services.CreateScope();
        
        var configuration = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        EnsureAsync(userManager, configuration).GetAwaiter().GetResult();
        return;

        static async Task EnsureAsync(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            string username = configuration.GetRequiredSection("Admin:Username").Value!;

            if (await userManager.FindByNameAsync(username) is not null)
            {
                return;
            }

            string email = configuration.GetRequiredSection("Admin:Email").Value!;
            string password = configuration.GetRequiredSection("Admin:Password").Value!;

            var adminUser = new IdentityUser(username) { Email = email };
            await userManager.CreateAsync(adminUser, password);

            await userManager.AddToRoleAsync(adminUser, RolesConstants.Admin);
        }
    }
}