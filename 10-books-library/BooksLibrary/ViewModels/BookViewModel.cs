namespace BooksLibrary.ViewModels;

public sealed class BookViewModel
{
    public BookViewMode ViewMode { get; init; }

    public Guid BookId { get; set; }
}