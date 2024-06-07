using System.Reflection.Metadata.Ecma335;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{

    //CREATE
    [HttpPost("v1/categories")]
    public async Task<IActionResult> CreateCategoryAsync([FromBody]Category categoryModel,
        [FromServices]BlogDataContext context)
    {

        try
        {
            await context.Categories.AddAsync(categoryModel);
            await context.SaveChangesAsync();
        
            return Created($"v1/categories/{categoryModel.Id}", categoryModel);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, "[E0001] - Não foi possível incluir a categoria.");
        }
        catch (Exception e)
        {
            return StatusCode(500, "[E0002] - Falha interna no servidor");
        }
    }
    
    //READ
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAllCategoryAsync(
        [FromServices]BlogDataContext context)
    {
        try
        {
            var categories  = await context.Categories.ToListAsync();
            return Ok(categories);
        }
        catch (Exception e)
        {
            return StatusCode(500, "[E0007] - Falha interna no servidor");
        }
    }
    
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetCategoryByIdAsync(
        [FromRoute] int id,
        [FromServices]BlogDataContext context)
    {
        try
        {
            var category  = await context.Categories.FirstOrDefaultAsync(x => x.Id == id );

            if (category == null)
                return NotFound();
        
            return Ok(category);
        }
        catch (Exception e)
        {
            return StatusCode(500, "[E0008] - Falha interna no servidor");
        }
    }

    //UPDATE
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> UpdateCategoryAsync(
        [FromRoute] int id,
        [FromBody]Category categoryModel,
        [FromServices]BlogDataContext context)
    {
        try
        {
            var category  = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id );

            if (category == null)
                return NotFound();

            category.Name = categoryModel.Name;
            category.Slug = categoryModel.Slug;
            
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        
            return Ok(category);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, "[E0005] - Não foi possível alterar a categoria.");
        }
        catch (Exception e)
        {
            return StatusCode(500, "[E0006] - Falha interna no servidor");
        }
    }

    //DELETE
    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteCategoryByIdAsync(
        [FromRoute] int id,
        [FromServices]BlogDataContext context)
    {
        try
        {
            var category  = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id );

            if (category == null)
                return NotFound();

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        
            return Ok(category);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, "[E0003] - Não foi possível excluir a categoria.");
        }
        catch (Exception e)
        {
            return StatusCode(500, "[E0004] - Falha interna no servidor");
        }
    }


}