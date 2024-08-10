namespace MagicTwins.Left;

public interface IToggleService
{
    Task<bool> IsToggledAsync(string userId);

    /// <returns>Is now toggled</returns>
    Task<bool> ToggleAsync(string userId);
}