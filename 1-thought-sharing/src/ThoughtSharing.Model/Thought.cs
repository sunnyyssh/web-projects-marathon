namespace ThoughtSharing.Model;

public class Thought
{
    public long Id { get; set; }
    
    public required string Thesis { get; set; }

    public string? Description { get; set; }
}