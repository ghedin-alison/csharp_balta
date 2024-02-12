// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using NewBlog.Data;
using NewBlog.Models;

using (var context = new NewBlogDataContext())
{
    // Insert só aqui usa o new
    // var tag = new Tag {Name = "SqlServer", Slug = "sqlserver" };
    // context.Tags.Add(tag);
    // context.SaveChanges();
    // Console.WriteLine("Tag incluida com sucesso");
    // Console.WriteLine("Works Fine");
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
    // var tags = context.Tags.
    //     Where(x=>x.Name.Contains(".NET")).
    //     ToList(); //executando a query
    //Quando fizer um filtro numa query, o ToList tem q ser a ultima coisa ex: context.Tags.Where(x=>x.Name.Contains(".NET")).ToList();

    // foreach (var tag in tags)
    // {
    //     Console.WriteLine($"Tag {tag.Name} / Slug: {tag.Slug}");
    // }
//Mapeamento
    // var user = new User
    // {
    //     Name = "Alison",
    //     Bio = "Developer and manager",
    //     Email = "alison@gmail.com",
    //     Image = "fotenha",
    //     Slug =  "alison-ghedin",
    //     PasswordHash = "a15165s1da"
    // };
    //
    // var category = new Category
    // {
    //     Name = "Backend",
    //     Slug = "backend"
    // };
    //
    // var post = new Post
    // {
    //     Author = user,
    //     Category = category,
    //     Body = "<p>Corpo</p>",
    //     Slug = "comecando-com-ef-core",
    //     Summary = "Neste artigo vaos aprender EF Core",
    //     Title = "Começando com Ef Core",
    //     CreateDate = DateTime.Now,
    //     LastUpdateDate = DateTime.Now
    // };
    //
    // context.Posts.Add(post);
    // context.SaveChanges();
    // Console.WriteLine("Post Adicionado");

    // query que traz todos os posts de um author
    // var posts = context
    //     .Posts
    //     .AsNoTracking()
    //     .Where(x=>x.AuthorId==2003)
    //     .OrderByDescending(x=>x.LastUpdateDate)
    //     .ToList();
    // foreach (var item in posts)
    //     Console.WriteLine($"{item.Title}");
    
    var posts = context
        .Posts
        .AsNoTracking()
        //Include é utilizado pra trazer listas de outras tabelas. Utiizar ? caso essa lista esteja vazia
        //Include sempre antes do order, sempre antes do wheere, funciona como inner/alter join
        .Include(x=>x.Author)
        .Include(x=>x.Category)
            //.ThenInclude(x=>x.XPTO) se houvesse uma tabela filha de categoria, sem relacionamento com posts, poderia busar suas info dessa maneira
        .OrderByDescending(x=>x.LastUpdateDate)
        .ToList();
    foreach (var item in posts)
        Console.WriteLine($"{item.Title} escrito por {item.Author?.Name} em {item.Category?.Name}"); // é uma boa prática utilizar Null Safe
}
