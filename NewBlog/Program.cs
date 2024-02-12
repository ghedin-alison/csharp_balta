// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using NewBlog.Data;
using NewBlog.Models;

using var context = new NewBlogDataContext();

// context.Users.Add(new User
// {
//     Bio = "Developer Cobol and Python",
//     Email = "ghedin@gmail.com",
//     Image = "foto-alison",
//     Slug = "alison-dev",
//     Name = "Alison J",
//     PasswordHash = "1234"
// });  
var user = context.Users.FirstOrDefault();
var post = new Post
{
    Author = user,
    Body = "Meu artigo",
    Category = new Category { Name = "Flexible", Slug = "flex"},
    CreateDate = DateTime.Now,
    Slug = "meu-artigo",
    Summary = "Nesse artigo vamos conferir...",
    Title = "Teste de post"
};

context.Posts.Add(post);
context.SaveChanges();
Console.WriteLine($"Post adicionado com sucesso {post.Id}");