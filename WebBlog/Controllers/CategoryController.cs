using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBlog.Data;
using WebBlog.Models;

namespace WebBlog.Controllers;

[ApiController]
public class CategoryController: ControllerBase
{
    // Get All
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
    {
        var categories = await context.Categories.ToListAsync();
        return Ok(categories);
    }

    // Get One
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        
        if(category == null)
            return NotFound();
        
        return Ok(category);
    }

    //Post
    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync(
        [FromBody] Category model,
        [FromServices] BlogDataContext context)
    {

        try
        {
            await context.Categories.AddAsync(model);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, "05XA1 - Não foi possível incluir a categoria.");
        }
        catch (Exception e)
        {
            return StatusCode(500, "05XA2 - Falha interna no servidor");
        }
        
        return Created($"v1/categories/{model.Id}", model);
    }
    
    //Put
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] Category model,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        
            category.Name = model.Name;
            category.Slug = model.Slug;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return Ok(model);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Não foi possível alterar.");
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
                return NotFound();

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return Ok(category);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Não foi possível excluir");
        }

    }
}