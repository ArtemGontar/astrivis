using Astrivis.Domain.Entities;

namespace Astrivis.Application.Services.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<TransactionDetails>> GetRecentTransactionsAsync(string walletAddress, ulong limit, string beforeSignature = null);
}