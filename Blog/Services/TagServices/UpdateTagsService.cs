using Blog.Models;
using Blog.Repositories;

namespace Blog.Services.TagServices;

public class UpdateTagsService
{
    public static void Load()
    {
        {
            Console.Clear();
            Console.WriteLine("Atualizar Tag");
            Console.WriteLine("-------------");
            
            Console.WriteLine("Digite o Id da Tag que quer atualizar: ");
            var id = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o Nome: ");
            var name = Console.ReadLine();
            
            Console.WriteLine("Digite o Slug: ");
            var slug = Console.ReadLine();
            
            Update(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagService.Load();
        }
    }
    private static void Update(Tag tag)
    {
        var repository = new Repository<Tag>();
        try
        {
            repository.Update(tag);
            Console.WriteLine($"Tag: {tag.Id} foi atualizada com sucesso");
        }
        catch (Exception e)
        {
            Console.WriteLine("Não foi possível atualizar a Tag");
            Console.WriteLine($"{e.Message}");
            throw;
        }
    }
}