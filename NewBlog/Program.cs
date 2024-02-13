// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using NewBlog.Data;
using NewBlog.Models;

// var user = new User
// {
//     Name = "Francieli",
//     Bio = "Banking Analyst",
//     Email = "fran@gmail.com",
//     GitHub = "github.com/fran-ghedin",
//     Image = "foto-fran",
//     PasswordHash = "123@#$789",
//     Slug = "teste-fran"
// };
//     
Consulta();

static async void Consulta()
{
    using var context = new NewBlogDataContext();
    var posts = await GetPosts(context);
    Console.WriteLine($"Posts: {posts.Count()}");
    Console.WriteLine("Finalizado!");
}

static async Task<List<Post>> GetPosts(NewBlogDataContext context)
    => await context.Posts.ToListAsync();