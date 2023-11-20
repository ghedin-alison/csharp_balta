Menu();

static void Menu(){
    Console.Clear();
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir arquivo de Texto");
    Console.WriteLine("2 - Novo arquivo de Texto");
    Console.WriteLine("3 - Sair");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: Environment.Exit(0);
            break;
        case 1: Abrir();
            break;
        case 2: Editar();
            break;
        default:
            Menu();
            break;
    }
}

static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");
    string path = Console.ReadLine();
    using (var file = new StreamReader(path))
    {
        string texto = file.ReadToEnd();
        Console.WriteLine(texto);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo(ESC para sair):");
    Console.WriteLine("----------------------");
    string texto = "";

    while (true)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Você pressionou ESC. Saindo da edição");
                break;
            }
            else
            {
                texto += keyInfo.KeyChar;
            }
        }
    }
    Console.WriteLine("continuou");
    Salvar(texto);
}

static void Salvar(string texto)
{
    Console.Clear();
    Console.WriteLine("Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();

// using garante a abertura e fechamento de um objeto no C#.
    using (var file = new StreamWriter(path))
    {
        file.Write(texto);
    }
    Console.WriteLine($"O arquivo foi salvo com sucesso em : {path}");
    Console.ReadLine();
    Menu();

}