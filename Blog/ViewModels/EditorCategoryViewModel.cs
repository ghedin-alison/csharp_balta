using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;

public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caracteres"), MinLength(3)]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Slug é obrigatório")]
    public string Slug { get; set; } = null!;
}