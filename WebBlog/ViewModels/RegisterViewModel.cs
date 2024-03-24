using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
    public string Email { get; set; }
}