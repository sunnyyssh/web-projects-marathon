using BooksLibrary.Model;
using Microsoft.EntityFrameworkCore;
// ReSharper disable StringLiteralTypo

namespace BooksLibrary.Database;

public static class SeedDatabase
{
    public static IServiceProvider EnsureMainBooksExist(this IServiceProvider services)
    {
        var libraryContext = services.GetRequiredService<LibraryDbContext>();
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