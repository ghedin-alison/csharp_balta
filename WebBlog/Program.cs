using WebBlog.Data;
using WebBlog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.
    Services.
    AddControllers().
    ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    }); //omite o tratamento de validação automática do .Net
builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>(); //Sempre criar uma nova instância
// builder.Services.AddScoped<>(); //Cria uma instância por requisição
// builder.Services.AddSingleton<>(); // Cria uma instância por app

var app = builder.Build();
app.MapControllers();

app.Run();
