using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;


public class CreatePostViewModel
{
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres"), MinLength(3)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Summary é obrigatório")]
    [StringLength(30, ErrorMessage = "Tamanho máximo de 30 caracteres"), MinLength(3)]
    public string Summary { get; set; }

    [Required(ErrorMessage = "Body é obrigatório")]
    [StringLength(30, ErrorMessage = "Tamanho máximo de 400 caracteres"), MinLength(3)]
    public string Body { get; set; }

    [Required(ErrorMessage = "Slug é obrigatório")]
    public string Slug { get; set; }
    
    [Required(ErrorMessage = "Categoria é obrigatória")]
    public string Category { get; set; }
    
    [Required(ErrorMessage = "Author é obrigatório")]
    public string Author { get; set; }
    
}