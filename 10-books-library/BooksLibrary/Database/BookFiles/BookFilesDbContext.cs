using BooksLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Database;

public sealed class BookFilesDbContext : DbContext
{
    public BookFilesDbContext(DbContextOptions<BookFilesDbContext> options) : base(options)
    { }

    public DbSet<BookDatabaseFileData> BookFiles => Set<BookDatabaseFileData>();
}