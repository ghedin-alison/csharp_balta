using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
public class PostController: ControllerBase
{
    //CREATE
    [HttpPost("v1/posts")]
    public async Task<IActionResult> CreatePostAsync(
        CreatePostViewModel model, 
        BlogDataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(
                new ResultViewModel<Post>(ModelState.GetErrors()));

        try
        {
            var post = new Post
            {
                Id = 0,
                Title = model.Title,
                Summary = model.Summary,
                Body = model.Body,
                Slug = model.Slug.ToLower(),
                CreateDate = DateTime.Now,
                LastUpdateDate = null,
                Category = model.Category,
                Author = model.Author
                
            };
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        
            return Created($"v1/posts/{post.Id}", 
                new ResultViewModel<Post>(post));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Post>("[P0001] - Não foi possível incluir o post."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Post>("[P0002] - Falha interna no servidor"));
        }
    }
}