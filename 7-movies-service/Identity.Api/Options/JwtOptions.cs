using System.ComponentModel.DataAnnotations;

namespace Identity.Api;

public class JwtOptions
{
    [Required]
    public required string Issuer { get; set; }

    [Required]
    public required string Audience { get; set; }
    
    [Required]
    public required string Key { get; set; }
}