using Microsoft.EntityFrameworkCore;

namespace MagicTwins.Left.Database;

public sealed class LeftDbContext : DbContext
{
    public LeftDbContext(DbContextOptions<LeftDbContext> options) : base(options)
    { }

    public DbSet<LeftToggleEntry> ToggleEntries => Set<LeftToggleEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeftToggleEntry>().HasKey(entry => entry.UserId);
    }
}