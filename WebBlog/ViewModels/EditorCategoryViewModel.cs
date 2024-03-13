using System.ComponentModel.DataAnnotations;

namespace WebBlog.ViewModels;

public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(40, MinimumLength = 10, ErrorMessage = "Esse campo deve ter entre 10 e 40 caracteres")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Campo é obrigatório")]
    public string Slug { get; set; }
}