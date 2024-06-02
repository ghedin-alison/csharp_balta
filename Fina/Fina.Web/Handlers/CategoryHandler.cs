using System.Net.Http.Json;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using MudBlazor;

namespace Fina.Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        //TODO try/catch
        //implementar resiliencia nessas chamada. Retry pattern com Poly
        //https://alastaircrabtree.com/posts/implementing-the-retry-pattern-using-polly/
        var result = await _httpClient.PostAsJsonAsync("v1/categories", request);
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
               ?? new Response<Category?>(null, 400, "Falha ao criar Categoria");
        
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var result = await _httpClient.DeleteAsync($"v1/categories{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
               ?? new Response<Category?>(null, 400, "Não foi possível excluir a categoria");
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        => await _httpClient.GetFromJsonAsync<Response<Category?>>($"v1/categories{request.Id}")
        ?? new Response<Category?>(null, 400, "Categoria não encontrada");
    
    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    //get não precisa de tratamento por isso não temos a variável result
        => await _httpClient.GetFromJsonAsync<PagedResponse<List<Category>?>>($"v1/categories")
           ?? new PagedResponse<List<Category>?>(null, 400, "Não foi possível obter as categorias");

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        //get não precisa de tratamento por isso não temos a variável result
        var result = await _httpClient.PutAsJsonAsync($"v1/categories{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
               ?? new Response<Category?>(null, 400, "Falha ao alterar a Categoria");
    }
}