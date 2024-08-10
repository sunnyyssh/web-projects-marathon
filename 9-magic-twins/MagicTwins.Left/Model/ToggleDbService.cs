using MagicTwins.Left.Database;

namespace MagicTwins.Left;

public sealed class ToggleDbService : IToggleService
{
    private readonly LeftDbContext _dbContext;

    public ToggleDbService(LeftDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> IsToggledAsync(string userId)
    {
        return await _dbContext.ToggleEntries.FindAsync(userId) is { Toggled: true };
    }

    public async Task<bool> ToggleAsync(string userId)
    {
        bool toggled;
        if (await _dbContext.ToggleEntries.FindAsync(userId) is { } toggleEntry)
        {
            toggleEntry.Toggled = !toggleEntry.Toggled;
            toggled = toggleEntry.Toggled;
            _dbContext.ToggleEntries.Update(toggleEntry);
        }
        else
        {
            _dbContext.ToggleEntries.Add(new LeftToggleEntry { UserId = userId, Toggled = true });
            toggled = true;
        }

        await _dbContext.SaveChangesAsync();
        return toggled;
    }
}