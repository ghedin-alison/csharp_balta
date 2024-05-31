using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}