using Microsoft.EntityFrameworkCore;
using ZooService.Model.Zoo;

namespace ZooService.ZoosApi.Model;

public class ZoosDbContext(DbContextOptions<ZoosDbContext> options) : DbContext(options)
{
    public DbSet<ZooInfo> Zoos => Set<ZooInfo>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .Property(t => t.Cost)
            .HasColumnType("decimal(8, 2)");
    }
}
