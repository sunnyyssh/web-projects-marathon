using Microsoft.EntityFrameworkCore;
using ZooService.Model.Zoo;
using ZooService.ZoosApi.Model;

namespace ZooService.ZoosApi.Model;

public class ZoosDbRepository(ZoosDbContext dbContext) : IRepository<ZooInfo>
{
    public async Task CreateAsync(ZooInfo zoo)
    {
        dbContext.Zoos.Add(zoo);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        if (await dbContext.Zoos.FindAsync(id) is not { } zoo)
        {
            return false;
        }

        dbContext.Zoos.Remove(zoo);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public Task<IEnumerable<ZooInfo>> GetAllAsync(bool loadAdditionalInfo = false)
    {
        return Task.FromResult<IEnumerable<ZooInfo>>(
            loadAdditionalInfo 
                ? dbContext.Zoos.Include(z => z.Location).AsNoTracking() 
                : dbContext.Zoos.AsNoTracking());
    }

    public async Task<ZooInfo?> GetByIdAsync(long id, bool loadAdditionalInfo = false)
    {
        return loadAdditionalInfo
            ? await dbContext.Zoos.FindAsync(id)
            : await dbContext.Zoos
                .Include(z => z.Location)
                .Where(z => z.Id == id)
                .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(ZooInfo zoo)
    {
        if (await dbContext.Zoos.FindAsync(zoo.Id) is null)
        {
            return false;
        }

        dbContext.Zoos.Update(zoo);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
