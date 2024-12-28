using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure.Clients;

public interface ISolanaClient
{
    Task<Wallet?> GetWalletInfoAsync(string walletId);

    Task<IEnumerable<TransactionDetails>> GetRecentTransactionsAsync(
        string walletAddress,
        ulong limit = 10,
        string beforeSignature = null);
}