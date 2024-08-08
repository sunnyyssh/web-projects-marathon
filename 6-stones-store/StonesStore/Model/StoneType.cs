using System.ComponentModel.DataAnnotations;

namespace StonesStore.Model;

public class StoneType
{
    public static readonly StoneType None = new();
    
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}