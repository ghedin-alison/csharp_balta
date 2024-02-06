// See https://aka.ms/new-console-template for more information

using NewBlog.Data;
using NewBlog.Models;

using (var context = new NewBlogDataContext())
{
    // Insert só aqui usa o new
    // var tag = new Tag {Name = "SqlServer", Slug = "sqlserver" };
    // context.Tags.Add(tag);
    // context.SaveChanges();
    // Console.WriteLine("Tag incluida com sucesso");
    
    //Update não usa o new, sempre recupera do banco
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1002);
    // tag.Name = ".Net";
    // tag.Slug = "dotnet";
    // context.Update(tag);
    // context.SaveChanges();
    // Console.WriteLine("Tag atualizada com sucesso");

    //Delete
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1002);
    // context.Remove(tag);
    // context.SaveChanges();
    // Console.WriteLine("Tag excluida com sucesso");
    
    //Read
    // var tags = context.Tags // Não executa a query
    var tags = context.Tags.
        Where(x=>x.Name.Contains(".NET")).
        ToList(); //executando a query
    //Quando fizer um filtro numa query, o ToList tem q ser a ultima coisa ex: context.Tags.Where(x=>x.Name.Contains(".NET")).ToList();

    foreach (var tag in tags)
    {
        Console.WriteLine($"Tag {tag.Name} / Slug: {tag.Slug}");
    }

}
