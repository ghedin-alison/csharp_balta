using Blog.Models;
using Blog.Repositories;

namespace Blog.Services.TagServices;

public class ListTagsService
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Tags");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuTagService.Load();
    }

    private static void List()
    {
        var repository = new Repository<Tag>();

        var tags = repository.Get();
        foreach (var item in tags)
        {
            Console.WriteLine($"Tag: {item.Id} - {item.Name} ({item.Slug})");
        }
    }
}