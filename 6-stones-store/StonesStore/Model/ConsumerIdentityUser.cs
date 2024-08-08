using Microsoft.AspNetCore.Identity;

namespace StonesStore.Model;

public class ConsumerIdentityUser : IdentityUser
{
    public List<Stone>? Stones { get; set; }
}
