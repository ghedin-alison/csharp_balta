// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using (var payment = new Payment())
{
    Console.WriteLine("processando o pagamento");
}

pagamentoBoleto.Vencimento = DateTime.Now;
pagamentoBoleto.Pagar();
pagamentoBoleto.NumeroBoleto = "1234";
class Payment: IDisposable
{
    //Propriedades
    public DateTime Vencimento;
    
    //Métodos
    public virtual void Pagar()
    {
    }

    public void Dispose()
    {
        Console.WriteLine("finalizar metodo");
    }
}

class  PagamentoBoleto: Payment
{
    DateTime Vencimento;

    public override void Pagar()
    {
        // Regra Boleto
    }

    public string NumeroBoleto { get; set; }

    public override string ToString()
    {
        return Vencimento.ToString();
    }
}

class PagamentoCartaoCredito : Payment
{
    public string NumeroCartao { get; set; }

    public PagamentoCartaoCredito()
    {
        
    }
    public override void Pagar()
    {
        //Regra do CC
    }
}

public static class Settings
{
    public static string API_URL { get; set; }
}
