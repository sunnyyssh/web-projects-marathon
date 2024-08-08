using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleShop.ConfigureOptions;
using SimpleShop.Database;
using SimpleShop.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ShopDbContext>(opts =>
{
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection"));
});

builder.Services.AddScoped<IProductsProvider, DbProductProvider>();
builder.Services.AddScoped<ICategoriesProvider, DbCategoriesProvider>();

builder.Services.AddDbContext<IdentityApplicationContext>(opts =>
{
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
    // Connections strings are specified in project secrets with 'dotnet user-secrets' utility.
    opts.UseSqlServer(builder.Configuration.GetConnectionString("IdentityApplicationConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityApplicationContext>();

builder.Services.ConfigureOptions<IdentityOptionsSetup>();
builder.Services.ConfigureOptions<JsonOptionsSetup>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();

app.Services.EnsureMainRolesExist();
app.Services.EnsureAdminUserExists();

app.Run();
