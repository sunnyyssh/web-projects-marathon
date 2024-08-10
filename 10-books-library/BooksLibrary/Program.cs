using BooksLibrary;
using BooksLibrary.Database;
using BooksLibrary.Database.Identity;
using BooksLibrary.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<IdentityAppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationNames.IdentityAppConnection));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityAppDbContext>();
builder.Services.ConfigureOptions<IdentityOptionsSetup>();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<LibraryDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationNames.LibraryConnection));
});

builder.Services.AddDbContext<BookFilesDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString(ConfigurationNames.BookFilesConnection));
});
builder.Services.AddScoped<IBookFilesStorage, BookDatabaseStorage>();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();
app.MapRazorPages();
app.MapBlazorHub();

app.Services.EnsureMainBooksExist();
app.Services.EnsureMainRolesExist();
app.Services.EnsureAdminUserExists();

app.Run();
