using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBlog.Models;
public class Post
{
    public int Id { get; set; }    
    public string Title { get; set; }    
    public string Summary { get; set; }    
    public string Body { get; set; }    
    public string Slug { get; set; }    
    public DateTime CreateDate { get; set; }    
    public DateTime LastUpdateDate { get; set; }    
    public Category Category { get; set; } // Traz a lista de Categorias com o nome de Category nessa tabela(subset)
    public User Author { get; set; } // Traz a lista de Usuários com o nome de Author nessa tabela(subset)
    public IList<Tag> Tags { get; set; }
    
}