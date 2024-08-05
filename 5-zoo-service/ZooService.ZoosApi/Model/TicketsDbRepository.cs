using Microsoft.EntityFrameworkCore;
using ZooService.Model.Zoo;
using ZooService.ZoosApi.Model;

namespace ZooService.ZoosApi.Model;

public class TicketsDbRepository(ZoosDbContext dbContext) : IRepository<Ticket>
{
    public async Task CreateAsync(Ticket ticket)
    {
        dbContext.Tickets.Add(ticket);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        if (await dbContext.Tickets.FindAsync(id) is not { } ticket)
        {
            return false;
        }

        dbContext.Tickets.Remove(ticket);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public Task<IEnumerable<Ticket>> GetAllAsync(bool loadAdditionalInfo = false)
    {
        return Task.FromResult<IEnumerable<Ticket>>(
            loadAdditionalInfo
                ? dbContext.Tickets.Include(t => t.Zoo).AsNoTracking()
                : dbContext.Tickets.AsNoTracking());
    }

    public async Task<Ticket?> GetByIdAsync(long id, bool loadAdditionalInfo = false)
    {
        return loadAdditionalInfo
            ? await dbContext.Tickets.FindAsync(id)
            : await dbContext.Tickets
                .Include(t => t.Zoo)
                .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> UpdateAsync(Ticket ticket)
    {
        if (await dbContext.Tickets.FindAsync(ticket.Id) is null)
        {
            return false;
        }

        dbContext.Tickets.Update(ticket);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
