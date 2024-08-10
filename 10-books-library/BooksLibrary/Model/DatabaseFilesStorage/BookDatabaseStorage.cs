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
    
    public async Task<DownloadFileResult> DownloadFileAsync(BookFileInfo fileInfo)
    {
        var fileData = await _dbContext.BookFiles.FirstOrDefaultAsync(f => f.FileInfoId == fileInfo.Id);

        return fileData is not null
            ? DownloadFileResult.Success(fileData)
            : DownloadFileResult.Error("Book file is not found");
    }

    public async Task<UploadFileResult> UploadFileAsync(BookFileInfo fileInfo, Stream stream)
    {
        byte[] buffer = new byte[stream.Length];
        await stream.ReadExactlyAsync(buffer, 0, checked((int)stream.Length));
        
        var existedFile = await _dbContext.BookFiles.FirstOrDefaultAsync(f => f.FileInfoId == fileInfo.Id);
        
        if (existedFile is null)
        {
            var createdFile = new BookDatabaseFileData
            {
                FileInfoId = fileInfo.Id,
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