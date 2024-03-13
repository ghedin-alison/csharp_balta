using System.ComponentModel.DataAnnotations;
namespace WebBlog.ViewModels;

public class EditCategoryViewModel
{
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string Slug { get; set; }
}