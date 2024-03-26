using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using WebBlog.Data;
using WebBlog.Extensions;
using WebBlog.Models;
using WebBlog.Services;
using WebBlog.ViewModels;

namespace WebBlog.Controllers;

[ApiController]
public class AccountController:ControllerBase
{
    [HttpPost("v1/accounts/")]
    public async Task<IActionResult> Post(
        [FromBody] RegisterViewModel model,
        [FromServices] BlogDataContext context)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            Slug = model.Email.Replace("@", "-").Replace(".", "-"),
            Bio = "obrigatoria por nao excluir o banco de dados",
            Image = "obrigatoria por nao excluir o banco de dados"
        };
        
        //Gerando uma senha forte
        var password = PasswordGenerator.Generate(25, includeSpecialChars: true, upperCase: false);
        //Hash da senha
        user.PasswordHash = PasswordHasher.Hash(password);

        try
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new
            {
                user = user.Email, password
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("0X400 - Este E-mail já está cadastrado"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("0X504 - Falha interna no servidor"));
        }
        
    }
    
    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginViewModel model,
        [FromServices] BlogDataContext context,
        [FromServices] TokenService tokenService)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
!!!Erro Aqui!!
        var user = await context
            .Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefault(x => x.Email == model.Email);
        
        if (user == null)
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválido."));

        if(!PasswordHasher.Verify(user.Password, model.Password));
            return StatusCode(401, new ResultViewModel<string>("Usuário ou password inválido."));
            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, null));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<string>("0x504 - Falha interna no servidor."));
                throw;
            }
    }
    

}