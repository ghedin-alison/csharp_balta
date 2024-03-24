using System.ComponentModel;
using System.Text;
using WebBlog;
using WebBlog.Data;
using WebBlog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key), // mesmo padrao usado no TokenDescriptor do Token Service
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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

// Essa configuração sempre nessa orderm, quem vc é e o q pode fazer
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
