using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Quiz.Host.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuizDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("QuizConnection"));
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
});

builder.Services.AddControllers();
builder.Services.Configure<JsonOptions>(opts =>
{
    opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    opts.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.UseBlazorFrameworkFiles("/webassembly");
app.MapFallbackToFile("/webassembly/{*path:nonfile}", "/webassembly/index.html");

if (app.Environment.IsDevelopment())
{
    app.Services.CreateScope().ServiceProvider
        .GetService<QuizDbContext>()?.AddMarmaladeDemoQuiz().Dispose();
}

app.Run();