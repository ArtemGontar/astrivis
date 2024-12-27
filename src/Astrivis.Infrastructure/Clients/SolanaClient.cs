using Astrivis.Domain.Entities;
using Solnet.Rpc;

namespace Astrivis.Infrastructure.Clients;

public class SolanaClient(IRpcClient rpcClient) : ISolanaClient
{
    public async Task<Wallet?> GetWalletInfoAsync(string walletAddress)
    {
        var wallet = new Wallet();
        var accountInfoTask = rpcClient.GetAccountInfoAsync(walletAddress);
        var tokenAccountsTask = rpcClient.GetTokenAccountsByOwnerAsync(walletAddress, tokenProgramId: "TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA");

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
                var token = new Token
                {
                    TokenAddress = tokenAccount.PublicKey,
                    Balance = tokenAccount.Account.Data.Parsed.Info.TokenAmount.AmountDecimal / 1000000000m // Convert lamports to SOL
                };

                // Check if the token is an NFT (Non-Fungible Token)
                if (tokenAccount.Account.Data.Parsed.Info.TokenAmount.AmountUlong == 1)
                {
                    // This token is likely an NFT
                    // var nftMetadata = await GetNFTMetadata(tokenAccount.PublicKey);
                    // token.Metadata = nftMetadata;

                    // Add to NonFungibleTokens collection
                    wallet.NonFungibleTokens.Add(token);
                }
                else
                {

                    // Add to FungibleTokens collection
                    wallet.FungibleTokens.Add(token);
                }
            }
        }

        return wallet;
    }


    // // Private method to fetch metadata for NFTs
    // private async Task<NftMetadata> GetNFTMetadata(string tokenAddress)
    // {
    //     // This is just an example. In a real implementation, this would fetch metadata associated with the NFT
    //     var metadata = await _rpcClient.GetTokenMetadataAsync(tokenAddress);
    //     return new NftMetadata
    //     {
    //         Name = metadata.Name,
    //         Symbol = metadata.Symbol,
    //         Uri = metadata.Uri,
    //         ImageUri = metadata.ImageUri // Assuming this is returned
    //     };
    // }

}