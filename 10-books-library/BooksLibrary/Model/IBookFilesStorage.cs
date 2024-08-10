namespace BooksLibrary.Model;

public interface IBookFilesStorage
{
    Task<DownloadFileResult> DownloadFileAsync(BookFileInfo fileInfo);

    Task<UploadFileResult> UploadFileAsync(BookFileInfo fileInfo, Stream stream);
}