using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Identity.Api;

public class TokenRegistrationRequest
{
    [Required]
    public Guid UserId { get; set; }

    [EmailAddress] 
    [Required]
    public required string Email { get; set; }
}