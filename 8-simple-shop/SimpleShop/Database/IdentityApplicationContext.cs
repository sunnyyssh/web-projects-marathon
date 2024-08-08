using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SimpleShop.Database;

public sealed class IdentityApplicationContext : IdentityDbContext
{
    public IdentityApplicationContext(DbContextOptions<IdentityApplicationContext> options) : base(options)
    { }
}