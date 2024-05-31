using System.Runtime.InteropServices.JavaScript;
using Fina.Api.Data;
using Fina.Core.Common;
using Fina.Core.Enums;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        if (request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
            request.Amount *= -1;
            
        var transaction = new Transaction
        {
            Title = request.Title,
            CreatedAt = DateTime.Now,
            PaidOrReceivedAt = request.PaidOrReceivedAt,
            Type = request.Type,
            Amount = request.Amount,
            CategoryId = request.CategoryId,
            UserId = request.UserId
        };

        try
        {
            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();
        
            return new Response<Transaction?>(transaction, 201, "Transação criada com sucesso.");
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Transaction?>(null, 500, "Não foi possível criar uma transação.");
        }
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction is null)
                return new Response<Transaction?>(null, 404, "Transação não encontrada");

            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();
            return new Response<Transaction?>(transaction, message: "Categoria excluída com sucesso.");
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Transaction?>(null, 500, "Não foi possível excluir a transacao.");
        }

    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        var transaction = await context
            .Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

        if (transaction is null)
            return new Response<Transaction?>(data: null, 404, "Transação não encontrada.");
        return new Response<Transaction?>(transaction);
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirstDay();
            request.EndDate ??= DateTime.Now.GetLastDay();
            
            //Query
            var query = context
                .Transactions
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId 
                            && x.CreatedAt >= request.StartDate 
                            && x.CreatedAt <= request.EndDate)
                .OrderBy(x => x.Title);
        
            //List
            var transactions = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        
            //Count
            var count = await query.CountAsync();
        
            return new PagedResponse<List<Transaction>?>(
                transactions, 
                totalCount: count, 
                currentPage: request.PageNumber, request.PageSize);
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new PagedResponse<List<Transaction>?>(null, 500, "Transações não encontradas");
        }
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {

        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);   
            
            if (transaction is null)
                return new Response<Transaction?>(null, 404, "Transação não encontrada");

            if (request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
                request.Amount *= -1;

            transaction.Title = request.Title;
            transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
            transaction.Type = request.Type;
            transaction.Amount = request.Amount;
            transaction.CategoryId = request.CategoryId;
            transaction.UserId = request.UserId;

            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
        
            return new Response<Transaction?>(transaction, 201, "Transação alterada com sucesso.");
        }
        catch (Exception e)
        {
            //TODO
            //Serilog, OpenTelemetry
            Console.WriteLine(e.Message);
            return new Response<Transaction?>(null, 500, "Não foi possível criar uma transação.");
        }
    }
}