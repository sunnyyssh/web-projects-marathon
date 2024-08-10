using BooksLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Controllers;

[ApiController]
[Route("/api/files")]
public sealed class BookFilesController : ControllerBase
{
    private readonly IBookFilesStorage _filesStorage;

    public BookFilesController(IBookFilesStorage filesStorage)
    {
        _filesStorage = filesStorage;
    }

    [HttpGet("download/{fileId}")]
    public async Task<IActionResult> DownloadAsync(Guid fileId)
    {
        var result = await _filesStorage.DownloadFileAsync(fileId);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return File(result.Data.OpenReadStream(), result.Data.MimeType, result.Data.FileName);
    }
}