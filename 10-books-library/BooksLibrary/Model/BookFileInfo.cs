namespace BooksLibrary.Model;

public sealed class BookFileInfo
{
    public Guid Id { get; set; }

    public required string Format { get; set; }
}