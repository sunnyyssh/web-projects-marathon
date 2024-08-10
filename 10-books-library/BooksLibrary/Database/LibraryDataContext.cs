using BooksLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Database;

public sealed class LibraryDataContext : DbContext
{
    public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
    { }

    public DbSet<BookInfo> Books => Set<BookInfo>();

    public DbSet<AuthorInfo> Authors => Set<AuthorInfo>();

    public DbSet<BookFileInfo> BookFiles => Set<BookFileInfo>();
}