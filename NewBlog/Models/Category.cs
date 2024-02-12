using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBlog.Models;

[Table("Category")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Gerado automat. pelo banco de dados
    public int Id { get; set; }    
    [Required] //NOT Null
    [MaxLength(80)] // tamanho maximo
    [MinLength(3)] // tamanho minimo
    [Column("Name", TypeName = "NVARCHAR")]
    public string Name { get; set; }    
    [Required] //NOT Null
    [MaxLength(80)] // tamanho maximo
    [MinLength(3)] // tamanho minimo
    [Column("Slug", TypeName = "VARCHAR")]
    public string Slug { get; set; }    
}