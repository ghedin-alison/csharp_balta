using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description,
            UserId = request.UserId
        };
        try
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category, 201, "Categoria criada com sucesso.");
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Category?>(null, 500, "Não foi possível criar uma categoria.");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => request.Id == x.Id && request.UserId == x.UserId);
            if (category is null)
                return new Response<Category?>(null, 404, "Categoria não encontrada");


            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category, message:"Categoria excluída com sucesso.");
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Category?>(null, 500, "Não foi possível excluir a categoria.");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => request.Id == x.Id && request.UserId == x.UserId);
            if (category is null)
                return new Response<Category?>(null, 404, "Categoria não encontrada");
            return new Response<Category?>(category);
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Category?>(null, 500, "Não foi possível encontrar a categoria.");
        }
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            //Query
            var query = context
                .Categories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Title);
        
            //List
            var categories = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        
            //Count
            var count = await query.CountAsync();

            return new PagedResponse<List<Category>?>(
                categories,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new PagedResponse<List<Category>?>(null, 500, "Categorias não encontradas");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => request.Id == x.Id && request.UserId == x.UserId);
            if (category is null)
                return new Response<Category?>(null, 404, "Categoria não encontrada");
            
            category.Title = request.Title;
            category.Description = request.Description;
            
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category, message:"Categoria alterada com sucesso.");
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Category?>(null, 500, "Não foi possível alterar uma categoria.");
        }
    }
}