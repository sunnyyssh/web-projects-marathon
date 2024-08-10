using System.Text.Json.Serialization;

namespace BooksLibrary.Model;

public sealed class BookInfo
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }
    
    public AuthorInfo? Author { get; set; }
    
    public Guid? FileId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BookFileInfo? FileInfo { get; set; }
}