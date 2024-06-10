using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{

    //CREATE
    [HttpPost("v1/categories")]
    public async Task<IActionResult> CreateCategoryAsync(
        [FromBody]EditorCategoryViewModel categoryModel,
        [FromServices]BlogDataContext context)
    {

        if (!ModelState.IsValid) // Criada extensão do model state pra pegar os erros de validação do ResultViewModel
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
        
        try
        {
            var category = new Category
            {
                Id = 0,
                Name = categoryModel.Name,
                Slug = categoryModel.Slug.ToLower()
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        
            return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0001] - Não foi possível incluir a categoria."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0002] - Falha interna no servidor"));
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
            return Ok(new ResultViewModel<List<Category>>(categories));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("[E0007] - Falha interna no servidor"));
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
                return NotFound(new ResultViewModel<Category>("Categoria não encontrada."));
        
            return Ok(new ResultViewModel<Category>(category));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0008] - Falha interna no servidor") );
        }
    }

    //UPDATE
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> UpdateCategoryAsync(
        [FromRoute] int id,
        [FromBody]EditorCategoryViewModel categoryModel,
        [FromServices]BlogDataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));

        try
        {
            var category  = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id );

            if (category == null)
                return NotFound(new ResultViewModel<Category>("Categoria não encontrada."));

            category.Name = categoryModel.Name;
            category.Slug = categoryModel.Slug;
            
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        
            return Ok(new ResultViewModel<Category>(category));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0005] - Não foi possível alterar a categoria."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0006] - Falha interna no servidor"));
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
                return NotFound(new ResultViewModel<Category>("Categoria não encontrada."));

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        
            return Ok(new ResultViewModel<Category>(category));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0003] - Não foi possível excluir a categoria."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("[E0004] - Falha interna no servidor"));
        }
    }


}