using System.ComponentModel.DataAnnotations;

namespace MagicTwins.Auth.Model;

public sealed class SignInDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}