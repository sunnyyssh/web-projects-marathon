namespace MagicTwins.Infrastructure;

public record User(string Id, string Name, IReadOnlyList<string>? Roles = null);