using Microsoft.EntityFrameworkCore;

namespace ThoughtSharing.Model;

public class ThoughtsDbContext(DbContextOptions<ThoughtsDbContext> opts) : DbContext(opts)
{
    public DbSet<Thought> Thoughts => Set<Thought>();
}