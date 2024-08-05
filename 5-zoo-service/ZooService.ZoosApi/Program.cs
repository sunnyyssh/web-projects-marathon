using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using ZooService.Model.Zoo;
using ZooService.ZoosApi;
using ZooService.ZoosApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZoosDbContext>(opts => 
{
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ZoosConnection"));
});
builder.Services.AddScoped<IRepository<ZooInfo>, ZoosDbRepository>();
builder.Services.AddScoped<IRepository<Ticket>, TicketsDbRepository>();

builder.Services.AddControllers();

builder.Services.Configure<JsonOptions>(opts =>
{
    opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
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
