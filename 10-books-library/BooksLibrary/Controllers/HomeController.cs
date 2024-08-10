using BooksLibrary.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Controllers;

[Route("/")]
[Route("/home")]
public sealed class HomeController : Controller
{
    private readonly LibraryDbContext _libraryDbContext;

    public HomeController(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    [HttpGet("")]
    [Route("index")]
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
}