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

    public async Task<Wallet?> GetWalletInfoAsync(string walletAddress)
    {
        var wallet = new Wallet();
        var accountInfoTask = _rpcClient.GetAccountInfoAsync(walletAddress);
        var tokenAccountsTask = _rpcClient.GetTokenAccountsByOwnerAsync(walletAddress, tokenProgramId: "TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA");

        var accountInfo = await accountInfoTask;
        if (accountInfo.WasSuccessful && accountInfo.Result != null)
        {
            wallet.Id = Guid.NewGuid();
            wallet.Balance = accountInfo.Result.Value.Lamports / 1000000000m; // Convert lamports to SOL
            wallet.WalletAddress = walletAddress;
        }

        var tokenAccounts = await tokenAccountsTask;
        if (tokenAccounts.WasSuccessful && tokenAccounts.Result != null)
        {
            foreach (var tokenAccount in tokenAccounts.Result.Value)
            {
                wallet.Tokens.Add(new Token
                {
                    TokenAddress = tokenAccount.PublicKey,
                    Balance = tokenAccount.Account.Data.Parsed.Info.TokenAmount.AmountDecimal / 1000000000m // Convert lamports to SOL
                });
            }
        }
        return wallet;
    }
}