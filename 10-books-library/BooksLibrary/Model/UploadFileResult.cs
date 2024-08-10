using System.Diagnostics.CodeAnalysis;

namespace BooksLibrary.Model;

public sealed class UploadFileResult
{
    [MemberNotNullWhen(false, nameof(ErrorMessage))]
    public bool IsSuccess { get; }
    
    public bool Overwritten { get; }
    
    public string? ErrorMessage { get; }

    public static UploadFileResult Success(bool overwritten)
    {
        return new UploadFileResult(true, overwritten, null);
    }

    public static UploadFileResult Error(string message)
    {
        return new UploadFileResult(false, false, message);
    }

    private UploadFileResult(bool success, bool overwritten, string? errorMessage)
    {
        IsSuccess = success;
        Overwritten = overwritten;
        ErrorMessage = errorMessage;
    }
}