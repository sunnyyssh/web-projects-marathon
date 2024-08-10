using BooksLibrary.Database;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Model;

public sealed class BookDatabaseStorage : IBookFilesStorage
{
    private readonly BookFilesDbContext _dbContext;

    public BookDatabaseStorage(BookFilesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<DownloadFileResult> DownloadFileAsync(Guid bookId)
    {
        var fileData = await _dbContext.BookFiles.FirstOrDefaultAsync(f => f.BookId == bookId);

        return fileData is not null
            ? DownloadFileResult.Success(fileData)
            : DownloadFileResult.Error("Book file is not found");
    }

    public async Task<UploadFileResult> UploadFileAsync(Guid bookId, Stream stream)
    {
        byte[] buffer = new byte[stream.Length];
        await stream.ReadExactlyAsync(buffer, 0, checked((int)stream.Length));
        
        var existedFile = await _dbContext.BookFiles.FirstOrDefaultAsync(f => f.BookId == bookId);
        
        if (existedFile is null)
        {
            var createdFile = new BookDatabaseFileData
            {
                BookId = bookId,
                Bytes = buffer
            };
            
            _dbContext.Add(createdFile);
            await _dbContext.SaveChangesAsync();
            
            return UploadFileResult.Success(false);
        }

        existedFile.Bytes = buffer;

        _dbContext.Update(existedFile);
        await _dbContext.SaveChangesAsync();

        return UploadFileResult.Success(true);
    }
}