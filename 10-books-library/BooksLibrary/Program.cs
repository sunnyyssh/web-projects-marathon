using BooksLibrary.Database;
using BooksLibrary.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibraryDbContext>(opts =>
{
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }

    opts.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationNames.LibraryConnection));
});
builder.Services.AddDbContext<BookFilesDbContext>(opts =>
{
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }

    opts.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationNames.BookFilesConnection));
});
builder.Services.AddScoped<IBookFilesStorage, BookDatabaseStorage>();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
