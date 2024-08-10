using BooksLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Database;

public sealed class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    { }

    public DbSet<BookInfo> Books => Set<BookInfo>();

    public DbSet<AuthorInfo> Authors => Set<AuthorInfo>();

    public DbSet<BookFileInfo> BookFiles => Set<BookFileInfo>();
}