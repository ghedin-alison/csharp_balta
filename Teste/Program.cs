Console.WriteLine("Hello, World!");
Console.WriteLine("Teste, Debug1");
// Comentario
Console.WriteLine("Comentario");



var usuarioExpirado = true;

var letra = 'C';
var palavra = "string";


int? idade = null;
Console.WriteLine($"idade: {idade}");
idade = 30;
Console.WriteLine($"idade: {idade}");


string valor = "Ana";

switch (valor)
{
    case "João": Console.WriteLine("Não é o cara");
        break;
    case "Marcelo": Console.WriteLine("Não é o cara"); 
        break;
    case "Alison": Console.WriteLine("É o cara."); 
        break;
    default: Console.WriteLine("Não encontrado"); 
        break;
    
    
}


for(int i = 5; i >= 1; i--)
{
    Console.WriteLine($"i: {i}");
}

int j = 10;
while (j >= 0)
{
    Console.WriteLine($"j: {j}");
    j--;
}
    
    
// void => Não retorna nada Vazio!!    

MeuMetodo();
string saudacao = RetornaNome("Alison", "Ghedin");
Console.WriteLine(saudacao);

static void MeuMetodo()
{
    Console.WriteLine("C# é mais uma linguagem pra conta!");
}

static string RetornaNome(string nome, string sobrenome)
{
    return $"Olá {nome} {sobrenome}!";
}

enum EEstadoCivil
{
    Solteiro = 1,
    Casado = 2,
    Divorciado = 3
    
}


// struct Cliente
// {
//     public string Nome { get; set; }
//     public EEstadoCivil EstadoCivil { get; set; }
// }
//
// var cliente = new Cliente("João", EEstadoCivil.Casado);

