using Microsoft.EntityFrameworkCore;
using ThoughtSharing.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ThoughtsDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("ThoughtsConnection"));
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
});

var app = builder.Build();

app.MapControllers();

app.Run();