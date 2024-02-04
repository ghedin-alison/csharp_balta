using Blog.Models;
using Blog.Repositories;

namespace Blog.Services.TagServices;

public class CreateTagsService
{
    public static void Load()
    {
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("-------------");
            
            Console.WriteLine("Digite o Nome: ");
            var name = Console.ReadLine();
            
            Console.WriteLine("Digite o Slug: ");
            var slug = Console.ReadLine();
            Create(new Tag
            {
                Name = name,
                Slug = slug
                });
            Console.ReadKey();
            MenuTagService.Load();
        }
        
    }

    public static void Create(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>();
            repository.Create(tag);
            Console.WriteLine($"Tag {tag.Name} criada com sucesso!!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Não foi possível salvar a Tag");
            Console.WriteLine($"{e.Message}");
            throw;
        }
    }
}