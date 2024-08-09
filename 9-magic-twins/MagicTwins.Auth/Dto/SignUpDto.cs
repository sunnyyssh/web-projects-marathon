namespace MagicTwins.Auth.Model;

public sealed class SignUpDto
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}