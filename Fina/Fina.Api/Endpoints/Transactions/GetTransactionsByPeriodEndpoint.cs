using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
            .WithName("Transactions: Get All by Period")
            .WithSummary("Recupera todas as Transações do Período")
            .WithDescription("Recupera todas as Transações do Período")
            .WithOrder(3)
            .Produces<PagedResponse<List<Transaction>?>>();
    }

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler, 
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {

        var request = new GetTransactionsByPeriodRequest
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };
        
        var response = await handler.GetByPeriodAsync(request);

        return response.IsSuccess 
            ? TypedResults.Ok(response) 
            : TypedResults.BadRequest(response);
    }
    
}