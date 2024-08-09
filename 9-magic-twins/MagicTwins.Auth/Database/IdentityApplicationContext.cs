using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicTwins.Auth.Database;

public sealed class IdentityApplicationContext : IdentityDbContext
{
    public IdentityApplicationContext(DbContextOptions<IdentityApplicationContext> options) : base(options)
    { }
}