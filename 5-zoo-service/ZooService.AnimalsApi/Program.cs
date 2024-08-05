using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using ZooService.AnimalsApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AnimalsDbContext>(opts => 
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AnimalsConnection"));
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
});


builder.Services.AddControllers();

builder.Services.Configure<JsonOptions>(opts => 
{
    opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
