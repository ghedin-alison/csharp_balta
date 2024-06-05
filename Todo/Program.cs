using Microsoft.AspNetCore.Mvc;
using Todo.Controllers;
using Todo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapControllers(); // mapear tudo que herda de controller

app.Run();
