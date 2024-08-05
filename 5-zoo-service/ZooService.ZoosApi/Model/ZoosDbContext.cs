using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using ZooService.Model.Zoo;

namespace ZooService.ZooApi.Model;

public class ZoosDbContext(DbContextOptions<ZoosDbContext> options) : DbContext(options)
{
    public DbSet<Zoo> Zoos => Set<Zoo>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .Property(t => t.Cost)
            .HasColumnType("decimal(8, 2)");
    }
}
