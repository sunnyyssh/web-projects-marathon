using System.Text.Json.Serialization;

namespace BooksLibrary.Model;

public sealed class BookInfo
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }
    
    public AuthorInfo? Author { get; set; }
}