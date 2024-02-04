using Blog.Models;
using Blog.Repositories;

namespace Blog.Services.TagServices;

public class DeleteTagsService
{
    public static void Load()
    {
        {
            Console.Clear();
            Console.WriteLine("Excluir Tag");
            Console.WriteLine("-------------");
            
            Console.WriteLine("Digite o Id da Tag que quer excluir: ");
            var id = int.Parse(Console.ReadLine()!);

            Delete(id);
            Console.ReadKey();
            MenuTagService.Load();
        }
    }

    private static void Delete(int id)
    {
        var repository = new Repository<Tag>();
        try
        {
            repository.Delete(id);
            Console.WriteLine($"Tag {id} foi excluída com sucesso");
        }   
        catch (Exception e)
        {
            Console.WriteLine("Não foi possível excluir a Tag");
            Console.WriteLine($"{e.Message}");
            throw;
        }
    }
}