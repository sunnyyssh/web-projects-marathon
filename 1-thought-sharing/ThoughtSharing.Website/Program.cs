using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;
using ThoughtSharing.Website.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddOptions<ThoughtApiOptions>()
    .Configure(opts =>
    {
        opts.BaseUrl = new Uri(builder.Configuration["ThoughtsApiBaseUrl"] ?? throw new InvalidOperationException());
    });
builder.Services.AddScoped<ThoughtApiClient>();
builder.Services.Configure<JsonOptions>(opts =>
{
    opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllers();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}");

app.Run();