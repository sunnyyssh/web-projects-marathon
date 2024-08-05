using Microsoft.EntityFrameworkCore;
using ZooService.ZooApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZoosDbContext>(opts => 
{
    if (builder.Environment.IsDevelopment())
    {
        opts.EnableSensitiveDataLogging();
    }
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ZoosConnection"));
});

builder.Services.AddControllers();

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
