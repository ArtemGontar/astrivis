using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure.Clients;

public interface ISolanaClient
{
    Task<Wallet?> GetWalletInfoAsync(string walletId);
}