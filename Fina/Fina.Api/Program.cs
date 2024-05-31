using Fina.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = 
    "Server=localhost,1433;Database=Fina;User ID=sa;Password=1q2w3e4r@#$;encrypt=False;";

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
