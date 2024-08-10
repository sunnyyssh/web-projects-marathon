namespace BooksLibrary.Model;

public static class BookFileFormats
{
    public const string PdfExtension = ".pdf";

    public const string PdfMimeType = "application/pdf";

    public const string TxtExtension = ".txt";

    public const string TxtMimeType = "text/plain";

    public static string? MimeToExtension(string mimeType)
    {
        return mimeType switch
        {
            PdfMimeType => PdfExtension,
            TxtMimeType => TxtExtension,
            _ => null,
        };
    }

    public static string? ExtensionToMime(string extension)
    {
        return extension switch
        {
            PdfExtension => PdfMimeType,
            TxtExtension => TxtMimeType,
            _ => null,
        };
    }
}