using System.ComponentModel.DataAnnotations;

namespace ThoughtSharing.Model;

public class Thought
{
    public long Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public required string Thesis { get; set; }

    public string? Description { get; set; }
}