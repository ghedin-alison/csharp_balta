var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Ok("Hello World!"));
app.MapGet("/{nome}", (string nome) => Results.Ok($"Olá {nome.ToUpper()}"));
app.MapPost("/", (User user) => Results.Ok(user));

app.Run();


public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}