using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = 
    "Server=localhost,1433;Database=Fina;User ID=sa;Password=1q2w3e4r@#$;encrypt=False;";

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
// Associando a interface com os handlers
//                          <o que o ele sabe resolver, como ele vai resolver>
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
