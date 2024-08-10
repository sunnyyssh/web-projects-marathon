using BooksLibrary.Database;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Model;

public sealed class BookDatabaseStorage : IBookFilesStorage
{
    private readonly LibraryDbContext _libraryDbContext;
    private readonly BookFilesDbContext _filesDbContext;

    public BookDatabaseStorage(LibraryDbContext libraryDbContext, BookFilesDbContext filesDbContext)
    {
        _libraryDbContext = libraryDbContext;
        _filesDbContext = filesDbContext;
    }

    public async Task<DownloadFileResult> DownloadFileAsync(Guid bookId)
    {
        var fileData = await _filesDbContext.BookFiles.FirstOrDefaultAsync(f => f.BookId == bookId);

        return fileData is not null
            ? DownloadFileResult.Success(fileData)
            : DownloadFileResult.Error("Book file is not found");
    }

    public async Task<UploadFileResult> UploadFileAsync(Guid bookId, string mimeType, string fileName, Stream stream)
    {
        byte[] buffer = new byte[stream.Length];
        await stream.ReadExactlyAsync(buffer, 0, checked((int)stream.Length));

        var existedFile = await _filesDbContext.BookFiles.FirstOrDefaultAsync(f => f.BookId == bookId);

        if (existedFile is null)
        {
            var createdFile = new BookDatabaseFileData
            {
                BookId = bookId,
                Bytes = buffer,
                FileName = fileName,
                MimeType = mimeType,
            };

            _filesDbContext.Add(createdFile);
            await _filesDbContext.SaveChangesAsync();

            return UploadFileResult.Success(false);
        }

        existedFile.Bytes = buffer;

        _filesDbContext.Update(existedFile);
        await _filesDbContext.SaveChangesAsync();

        return UploadFileResult.Success(true);
    }
}