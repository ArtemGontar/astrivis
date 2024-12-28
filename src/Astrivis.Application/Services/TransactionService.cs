using Astrivis.Application.Services.Interfaces;
using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Clients;

namespace Astrivis.Application.Services;

public class TransactionService(ISolanaClient solanaClient) : ITransactionService
{
    private readonly ISolanaClient _solanaClient = solanaClient;

    public async Task<IEnumerable<TransactionDetails>> GetRecentTransactionsAsync(string walletAddress, ulong limit, string beforeSignature = null)
    {
        return await _solanaClient.GetRecentTransactionsAsync(walletAddress, limit, beforeSignature);
    }
}