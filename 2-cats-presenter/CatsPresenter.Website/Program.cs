using System.Text.Json;
using CatsPresenter.Website.Model;
using Microsoft.AspNetCore.Http.Json;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<JsonOptions>(opts =>
{
    opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddRefitClient<ICatApiClient>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://api.thecatapi.com"));

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
