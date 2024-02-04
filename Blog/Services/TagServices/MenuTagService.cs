namespace Blog.Services.TagServices;

public class MenuTagService
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Tags");
        Console.WriteLine("==============");
        Console.WriteLine("Digite uma opção: ");
        Console.WriteLine();
        Console.WriteLine("1 - Listar tags");
        Console.WriteLine("2 - Cadastrar tags");
        Console.WriteLine("3 - Atualizar tags");
        Console.WriteLine("4 - Excluir tags");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                ListTagsService.Load();
                break;
            case 2:
                CreateTagsService.Load();
                break;
            case 3:
                UpdateTagsService.Load();
                break;
            case 4:
                DeleteTagsService.Load();
                break;
            default:
                Load();
                break;
                
        }
    }
}