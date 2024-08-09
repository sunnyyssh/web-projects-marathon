using System.IdentityModel.Tokens.Jwt;
using MagicTwins.Auth;
using MagicTwins.Auth.Database;
using MagicTwins.Auth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.Configure<JwtOptions>(opts =>
{
    opts.Issuer = builder.Configuration.GetRequiredSection("JwtSettings:Issuer").Value!;
    opts.Audience = builder.Configuration.GetRequiredSection("JwtSettings:Audience").Value!;
    opts.Key = builder.Configuration.GetRequiredSection("JwtSettings:Key").Value!;
    opts.ExpirationPeriod = TimeSpan.FromMinutes(30);
});

builder.Services.ConfigureOptions<JsonOptionsSetup>();

builder.Services.AddDbContext<IdentityApplicationContext>(opts =>
{
    // Sensitive data should be configured in 'dotnet user-secrets'.
    opts.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityApplicationContext>();
builder.Services.ConfigureOptions<IdentityOptionsSetup>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Services.EnsureMainRolesCreated();

app.Run();
