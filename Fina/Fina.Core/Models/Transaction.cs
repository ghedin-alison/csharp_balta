using Fina.Core.Enums;

namespace Fina.Core.Models;

public class Transaction
{
    // Poderia ser Guid pra ter maior controle, mas demora um pouco mais pra processar, 2 ciclos
    // Ameniza se criar um indice pro Guid na tabela
    // public Guid Id { get; set; } = Guid.NewGuid();
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidOrReceivedAt { get; set; }

    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    public decimal Amount { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

}