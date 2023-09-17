using Application.Book;
using Application.Book.Ports;
using Data;
using Data.Book;
using Domain.Book.Ports;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region IOC
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookManager, BookManager>();
#endregion

var connectionString = builder.Configuration.GetConnectionString("Main");
builder.Services.AddDbContext<LibraryDbContext>(
    options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
