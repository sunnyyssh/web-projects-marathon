using System.ComponentModel.DataAnnotations;

namespace StonesStore.Model;

public class Stone
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public long OwnerId { get; set; }

    [Required]
    public long TypeId { get; set; }
    
    public StoneType Type { get; set; } = StoneType.None;
}