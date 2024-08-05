using Microsoft.EntityFrameworkCore;
using ZooService.Model.Animals;

namespace ZooService.AnimalsApi;

public class AnimalsDbRepository(AnimalsDbContext dbContext) : IAnimalsRepository
{
    public async Task CreateAsync(AnimalInfo animal)
    {
        dbContext.Animals.Add(animal);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        if (await dbContext.Animals.FindAsync(id) is not { } animal)
        {
            return false;
        }

        dbContext.Animals.Remove(animal);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public Task<IEnumerable<AnimalInfo>> GetAllAsync(bool loadAdditionalInfo = false)
    {
        return Task.FromResult<IEnumerable<AnimalInfo>>(dbContext.Animals.AsNoTracking());
    }

    public async Task<AnimalInfo?> GetByIdAsync(long id, bool loadAdditionalInfo = false)
    {
        return loadAdditionalInfo 
            ? await dbContext.Animals.FindAsync(id)
            : await dbContext.Animals
                .Include(a => a.NaturalArea)
                .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> UpdateAsync(AnimalInfo animal)
    {
        if (await dbContext.Animals.FindAsync(animal.Id) is null)
        {
            return false;
        }

        dbContext.Animals.Update(animal);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
