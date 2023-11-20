using System.Threading.Channels;

Menu();

static void Menu()
{
    Console.Clear();
    
    Console.WriteLine("Qual operação gostaria de executar?");
    Console.WriteLine("1 - Soma");
    Console.WriteLine("2 - Subtração");
    Console.WriteLine("3 - Multiplicação");
    Console.WriteLine("4 - Divisão");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("-------------------------");
    Console.WriteLine("Selecione uma opção: ");
    short res = short.Parse(Console.ReadLine());

    switch (res)
    {
        case 1: Soma();
            break;
        case 2: Subtracao();
            break;
        case 3: Multiplicacao(); 
            break;
        case 4: Divisao();
            break;
        case 0: Sair();
            break;
        default: Menu(); 
            break; 
        
        
    }
    
}

static void Soma()
{
    Console.Clear();
    Console.WriteLine("Soma de dois valores!!");
    Console.Write("Primeiro Valor: ");
    double v1 = double.Parse(Console.ReadLine());

    Console.Write("Segundo Valor: ");
    double v2 = double.Parse(Console.ReadLine());

    double resultado = v1 + v2;

    Console.WriteLine();
    Console.WriteLine($"O resultado da soma é: {resultado}");
    Console.ReadKey();
    Menu();
}

static void Subtracao()
{
    Console.Clear();
    Console.WriteLine("Subtração de dois valores!!");
    Console.Write("Primeiro Valor: ");
    double v1 = double.Parse(Console.ReadLine());

    Console.Write("Segundo Valor: ");
    double v2 = double.Parse(Console.ReadLine());

    double resultado = v1 - v2;

    Console.WriteLine();
    Console.WriteLine($"O resultado da subtração é: {resultado}");
    Console.ReadKey();
    Menu();

}

static void Divisao()
{
    Console.Clear();
    Console.WriteLine("Divisão de dois valores!!");
    Console.Write("Primeiro Valor: ");
    double v1 = double.Parse(Console.ReadLine());
    Console.Write("Primeiro Valor: ");
    double v2 = double.Parse(Console.ReadLine());

    double resultado = v1 / v2;

    Console.WriteLine();
    
    Console.WriteLine($"O resultado da divisão é: {resultado}");
    Console.ReadKey();
    Menu();
}

static void Multiplicacao()
{
    Console.Clear();
    Console.WriteLine("Multiplicação de dois valores!!");
    Console.Write("Primeiro Valor: ");
    double v1 = double.Parse(Console.ReadLine());
    Console.Write("Primeiro Valor: ");
    double v2 = double.Parse(Console.ReadLine());

    double resultado = v1 * v2;

    Console.WriteLine();
    
    Console.WriteLine($"O resultado da multiplicação é: {resultado}");
    Console.ReadKey();
    Menu();
}

static void Sair()
{
    Console.WriteLine("Sistema Finalizado!!");
    Console.WriteLine("Até breve!!");
    System.Environment.Exit(0);
}