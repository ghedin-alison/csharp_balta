using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", HandleAsync)
            .WithName("Transactions: Delete")
            .WithSummary("Exclui uma Transação")
            .WithDescription("Exclui uma Transação")
            .WithOrder(2)
            .Produces<Response<Transaction?>>();
    }

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler, 
        long id)
    {

        var request = new DeleteTransactionRequest()
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };
        
        var response = await handler.DeleteAsync(request);

        return response.IsSuccess 
            ? TypedResults.Ok(response) 
            : TypedResults.BadRequest(response);
    }
    
}