using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StonesStore.Model;

public class ConsumerIdentityContext(DbContextOptions<ConsumerIdentityContext> options) : IdentityDbContext<ConsumerIdentityUser>(options)
{
    public DbSet<Stone> Stones => Set<Stone>();

    public DbSet<StoneType> StoneTypes => Set<StoneType>();
}
