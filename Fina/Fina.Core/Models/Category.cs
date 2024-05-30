namespace Fina.Core.Models;

public class Category
{
    // Poderia ser Guid pra ter maior controle, mas demora um pouco mais pra processar, 2 ciclos
    // Ameniza se criar um indice pro Guid na tabela
    // public Guid Id { get; set; } = Guid.NewGuid();
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string UserId { get; set; } = string.Empty;
}