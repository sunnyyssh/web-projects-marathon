namespace BooksLibrary.Model;

public sealed class BookDatabaseFileData : IBookFileData
{
    public Guid Id { get; set; }

    public required Guid BookId { get; set; }

    public required string MimeType { get; init; }

    public required string FileName { get; init; }

    public required byte[] Bytes { get; set; }

    public Stream OpenReadStream()
    {
        var stream = new MemoryStream(Bytes, false);
        return stream;
    }
}