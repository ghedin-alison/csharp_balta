using Todo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //add controllers
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.MapControllers(); // mapeia os controllers

app.Run();
