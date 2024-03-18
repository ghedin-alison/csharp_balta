using WebBlog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.
    Services.
    AddControllers().
    ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    }); //omite o tratamento de validação automática do .Net
builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();
app.MapControllers();

app.Run();
