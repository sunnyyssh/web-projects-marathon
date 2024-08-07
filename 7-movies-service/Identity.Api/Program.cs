using Identity.Api;
using Identity.Api.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JsonOptionsSetup>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();