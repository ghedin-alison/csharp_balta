using Fina.Api.Common.Api;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: Get By Id")
            .WithSummary("Recupera Categoria")
            .WithDescription("Recupera Categoria")
            .WithOrder(4)
            .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler, 
        long id)
    {

        var request = new GetCategoryByIdRequest()
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };
        
        var response = await handler.GetByIdAsync(request);

        return response.IsSuccess 
            ? TypedResults.Ok(response) 
            : TypedResults.BadRequest(response);
    }
    
}