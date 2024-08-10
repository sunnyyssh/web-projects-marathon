using BooksLibrary.Constants;
using BooksLibrary.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// ReSharper disable StringLiteralTypo

namespace BooksLibrary.Database;

public static class SeedDatabase
{
    public static IServiceProvider EnsureAdminUserExists(this IServiceProvider services)
    {
        var userManager = services.CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();
        var configuration = services.GetRequiredService<IConfiguration>();

        EnsureAsync(userManager, configuration).GetAwaiter().GetResult();

        return services;

        static async Task EnsureAsync(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            string adminName = configuration.GetRequiredSection(ConfigurationNames.AdminUserName).Value!;
            if (await userManager.FindByNameAsync(adminName) is not null)
            {
                return;
            }

            string adminPassword = configuration.GetRequiredSection(ConfigurationNames.AdminPassword).Value!;

            var adminUser = new IdentityUser(adminName);
            await userManager.CreateAsync(adminUser, adminPassword);
            await userManager.AddToRoleAsync(adminUser, UserRoles.Admin);
        }
    }

    public static IServiceProvider EnsureMainRolesExist(this IServiceProvider services)
    {
        var roleManager = services.CreateScope().ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        EnsureAsync(roleManager).GetAwaiter().GetResult();

        return services;

        static async Task EnsureAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
        }
    }

    public static IServiceProvider EnsureMainBooksExist(this IServiceProvider services)
    {
        var libraryContext = services.CreateScope().ServiceProvider
            .GetRequiredService<LibraryDbContext>();
        var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(typeof(SeedDatabase).FullName!);

        EnsureAsync(libraryContext, logger).ConfigureAwait(false)
            .GetAwaiter().GetResult();

        return services;

        static async Task EnsureAsync(LibraryDbContext libraryContext, ILogger logger)
        {
            if (await libraryContext.Books.AnyAsync())
            {
                logger.LogDebug("Main books already exist!");
                return;
            }

            var pushkin = new AuthorInfo
            {
                FullName = "Пушкин Александр Сергевич",
                Country = "Россия"
            };

            var tolstoy = new AuthorInfo
            {
                FullName = "Толстой Лев Николаевич",
                Country = "Россия"
            };

            var twain = new AuthorInfo
            {
                FullName = "Марк Твен",
                Country = "США"
            };

            var books = new BookInfo[]
            {
                new BookInfo
                {
                    Title = "Капитанская дочка",
                    Author = pushkin,
                },
                new BookInfo
                {
                    Title = "Война и мир",
                    Author = tolstoy,
                },
                new BookInfo
                {
                    Title = "Приключения Тома Сойера",
                    Author = twain,
                },
            };

            libraryContext.Books.AddRange(books);

            await libraryContext.SaveChangesAsync();

            logger.LogInformation("Main bboks created!");
        }
    }
}