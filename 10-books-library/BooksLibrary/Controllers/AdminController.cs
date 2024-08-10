using BooksLibrary.Constants;
using BooksLibrary.Database;
using BooksLibrary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Controllers;

[Authorize(Roles = UserRoles.Admin)]
[Route("/admin")]
public sealed class AdminController : Controller
{
    private readonly LibraryDbContext _libraryDbContext;

    public AdminController(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    [HttpGet("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        var books = await _libraryDbContext.Books
            .Include(b => b.Author)
            .ToArrayAsync();

        return View(books);
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(Guid id)
    {
        return View(new BookViewModel { BookId = id, ViewMode = BookViewMode.Edit });
    }
}