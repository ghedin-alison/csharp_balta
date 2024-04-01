using System.ComponentModel.DataAnnotations;

namespace WebBlog.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o E-mail.")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get;} 

    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get;} 
}