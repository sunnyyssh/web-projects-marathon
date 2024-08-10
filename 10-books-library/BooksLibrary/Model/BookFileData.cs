namespace BooksLibrary.Model;

public interface IBookFileData
{
    string MimeType { get; }

    string FileName { get; }
    
    Stream OpenReadStream();
}