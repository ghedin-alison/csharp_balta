using System.ComponentModel.DataAnnotations;
using Fina.Core.Enums;

namespace Fina.Core.Requests.Transactions;

public class UpdateTransactionRequest: Request
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Titulo Invalido")]
    public string Title { get; set; }  = String.Empty;

    [Required(ErrorMessage = "Tipo Invalido")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    
    [Required(ErrorMessage = "Valor Invalido")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Categoria Invalida")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Data Invalida")]
    public DateTime? PaidOrReceivedAt { get; set; }    
    
}