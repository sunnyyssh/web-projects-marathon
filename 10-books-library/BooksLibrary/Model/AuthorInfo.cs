namespace BooksLibrary.Model;

public sealed class AuthorInfo
{
    public Guid Id { get; set; }

    public required string FullName { get; set; }

    public required string Country { get; set; }
}