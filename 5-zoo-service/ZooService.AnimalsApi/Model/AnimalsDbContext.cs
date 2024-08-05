using Microsoft.EntityFrameworkCore;
using ZooService.Model.Animals;

namespace ZooService.AnimalsApi;

public class AnimalsDbContext(DbContextOptions<AnimalsDbContext> options) : DbContext(options)
{
    public DbSet<AnimalInfo> Animals => Set<AnimalInfo>();

    public DbSet<AreaInfo> Areas => Set<AreaInfo>();
}
