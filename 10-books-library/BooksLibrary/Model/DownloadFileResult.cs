using System.Diagnostics.CodeAnalysis;

namespace BooksLibrary.Model;

public sealed class DownloadFileResult
{
    [MemberNotNullWhen(true, nameof(Data))]
    [MemberNotNullWhen(false, nameof(ErrorMessage))]
    public bool IsSuccess { get; }

    public BookFileData? Data { get; set; }
    
    public string? ErrorMessage { get; }

    public static DownloadFileResult Success(BookFileData fileData)
    {
        return new DownloadFileResult(true, fileData, null);
    }

    public static DownloadFileResult Error(string message)
    {
        return new DownloadFileResult(false, null, message);
    }

    private DownloadFileResult(bool success, BookFileData? fileData, string? errorMessage)
    {
        IsSuccess = success;
        Data = fileData;
        ErrorMessage = errorMessage;
    }
}