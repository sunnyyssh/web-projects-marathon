namespace BooksLibrary.Model;

public sealed class BookDatabaseFileData : BookFileData
{
    public Guid Id { get; set; }

    public required Guid BookId { get; set; }

    public required byte[] Bytes { get; set; }
    
    public override Stream OpenReadStream()
    {
        var stream = new MemoryStream(Bytes, false);
        return stream;
    }
}