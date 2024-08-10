using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Database.Identity;

public sealed class IdentityAppDbContext : IdentityDbContext
{
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options)
    { }
}