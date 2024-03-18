using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBlog.Data;
using WebBlog.Extensions;
using WebBlog.Models;
using WebBlog.ViewModels;

namespace WebBlog.Controllers;

[ApiController]
public class CategoryController: ControllerBase
{
    // Get All
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
    {
        try
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(new ResultViewModel<List<Category>>(categories));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("05x04 - Falha interna no Servidor!"));
        }
    }

    // Get One
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        
            if(category == null)
                return NotFound(new ResultViewModel<Category>($"Categoria não encontrada."));
        
            return Ok(new ResultViewModel<Category>(category));
        }
        catch 
        {
            return StatusCode(500, new ResultViewModel<Category>("05x0 - Falha interna no Servidor!"));
        }
    }

    //Post
    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorCategoryViewModel model,
        [FromServices] BlogDataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
        
        try
        {
            var category = new Category
            {
                Name = model.Name,
                Slug = model.Name.ToLower()
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            
            return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Category>("05XA1 - Não foi possível incluir a categoria."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Category>("05XA2 - Falha interna no servidor"));
        }
    }
    
    //Put
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] EditorCategoryViewModel model,
        [FromServices] BlogDataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));

        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new ResultViewModel<Category>("Categoria não encontrada."));
        
            category.Name = model.Name;
            category.Slug = model.Slug;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Category>(category));
        }
        catch 
        {
            return StatusCode(500, new ResultViewModel<Category>("Não foi possível alterar."));
        }
    }
    
    // Delete
    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new ResultViewModel<Category>("Categoria não encontrada."));

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Category>(category));
        }
        catch 
        {
            return StatusCode(500, new ResultViewModel<Category>("Não foi possível excluir"));
        }

    }
}