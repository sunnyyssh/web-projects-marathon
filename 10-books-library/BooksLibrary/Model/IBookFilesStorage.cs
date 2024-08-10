namespace BooksLibrary.Model;

public interface IBookFilesStorage
{
    Task<DownloadFileResult> DownloadFileAsync(Guid bookId);
    
    Task<UploadFileResult> UploadFileAsync(Guid bookId, string mimeType, string fileName, Stream stream);
}