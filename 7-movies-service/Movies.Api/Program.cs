using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Movies.Api.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.ConfigureOptions<JsonOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddHttpLogging(opts =>
{
    opts.CombineLogs = true;
    opts.LoggingFields = HttpLoggingFields.RequestMethod | HttpLoggingFields.RequestHeaders |
                         HttpLoggingFields.ResponseStatusCode | HttpLoggingFields.ResponsePropertiesAndHeaders;
});

var app = builder.Build();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();