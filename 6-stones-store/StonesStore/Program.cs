using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StonesStore;
using StonesStore.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConsumerIdentityContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ConsumerIdentityConnection"));
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
});

builder.Services.AddIdentity<ConsumerIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ConsumerIdentityContext>();
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
