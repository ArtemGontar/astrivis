using Astrivis.Domain.Entities;
using Solnet.Rpc;

namespace Astrivis.Infrastructure.Clients;

public class SolanaClient : ISolanaClient
{
    private readonly IRpcClient _rpcClient;

    public SolanaClient(IRpcClient rpcClient)
    {
        _rpcClient = rpcClient;
    }

    public async Task<Wallet?> GetWalletInfoAsync(string walletId)
    {
        var accountInfo = await _rpcClient.GetAccountInfoAsync(walletId);
        if (accountInfo.WasSuccessful && accountInfo.Result != null)
        {
            return new Wallet
            {
                Id = Guid.NewGuid(),
                Balance = accountInfo.Result.Value.Lamports / 1000000000m, // Convert lamports to SOL
                WalletAddress = walletId
            };
        }
        return null;
    }
}