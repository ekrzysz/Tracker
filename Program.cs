using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tracker.Data;

var builder = WebApplication.CreateBuilder(args);

var fullPath = builder.Configuration["Db:ConnectionString"];

// Add services to the container.
// main init

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EntriesDbContext>(
    os => os.UseSqlServer(fullPath));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

