using Astrivis.Domain.Entities;
using Solnet.Rpc;
using Solnet.Rpc.Models;
using Solnet.Rpc.Types;
using TransactionDetails = Astrivis.Domain.Entities.TransactionDetails;

namespace Astrivis.Infrastructure.Clients;

public class SolanaClient(IRpcClient rpcClient) : ISolanaClient
{
    private static readonly string TokenProgramId = "TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA";

    private readonly IRpcClient _rpcClient = rpcClient;
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

    public async Task<IEnumerable<TransactionDetails>> GetRecentTransactionsAsync(
        string walletAddress,
        ulong limit = 10,
        string beforeSignature = null)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(walletAddress))
        {
            throw new ArgumentException("Wallet address must not be empty.", nameof(walletAddress));
        }

        // Fetch transactions
        var result = await _rpcClient.GetSignaturesForAddressAsync(walletAddress, limit, beforeSignature);

        if (!result.WasSuccessful)
        {
            throw new Exception($"Failed to fetch transactions: {result.Reason}");
        }

        var transactions = new List<TransactionDetails>();

        // Retrieve detailed information for each transaction
        foreach (var signatureInfo in result.Result)
        {
            var transactionResult = await _rpcClient.GetTransactionAsync(signatureInfo.Signature, Commitment.Confirmed);

            if (transactionResult.WasSuccessful && transactionResult.Result != null)
            {
                var meta = transactionResult.Result.Meta;
                var innerInstructions = meta?.InnerInstructions?.FirstOrDefault()?.Instructions;

                // if (innerInstructions != null)
                // {
                //     foreach (var instruction in innerInstructions)
                //     {
                //         if (instruction.ProgramId == TokenProgramId) // Filter only token transfer instructions
                //         {
                //             var parsed = instruction.Parsed;
                //             if (parsed != null && parsed.Info != null)
                //             {
                //                 var from = parsed.Info.TryGetValue("source", out var source) ? source.ToString() : "N/A";
                //                 var to = parsed.Info.TryGetValue("destination", out var destination) ? destination.ToString() : "N/A";
                //                 var amount = parsed.Info.TryGetValue("amount", out var tokenAmount) ? tokenAmount.ToString() : "N/A";
                //
                //                 transactions.Add(new TransactionDetails
                //                 {
                //                     Signature = signatureInfo.Signature,
                //                     Date = DateTimeOffset.FromUnixTimeSeconds(signatureInfo.BlockTime ?? 0).UtcDateTime,
                //                     From = from,
                //                     To = to,
                //                     Amount = amount
                //                 });
                //             }
                //         }
                //     }
                // }
            }
        }

        return transactions;
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

    // /// <summary>
    // /// Calculates the ROI based on token transfers in transaction history.
    // /// </summary>
    // private static decimal CalculateROI(List<TransactionDetails> transactions)
    // {
    //     decimal totalInvestment = 0;
    //     decimal totalProfit = 0;
    //
    //     foreach (var transaction in transactions)
    //     {
    //         // Analyze instructions for token transfers
    //         foreach (var instruction in transaction.Message.Instructions)
    //         {
    //             // Decode instruction for token transfers (assumes SPL Token Program involvement)
    //             if (instruction.ProgramId == "TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA")
    //             {
    //                 // Placeholder: Decode transfer amount and direction (to/from walletAddress)
    //                 // Use token metadata to get the price at the time of transfer
    //                 decimal transferAmount = 0; // Example, replace with decoded transfer data
    //                 decimal tokenPriceAtTransfer = 1; // Fetch price using a Solana price oracle
    //
    //                 if (IsOutgoing(transaction.Message.AccountKeys, instruction))
    //                 {
    //                     totalInvestment += transferAmount * tokenPriceAtTransfer;
    //                 }
    //                 else
    //                 {
    //                     totalProfit += transferAmount * tokenPriceAtTransfer;
    //                 }
    //             }
    //         }
    //     }
    //
    //     if (totalInvestment == 0) return 0;
    //
    //     return (totalProfit - totalInvestment) / totalInvestment;
    // }
    //
    // /// <summary>
    // /// Determines if a transaction instruction is outgoing from the wallet.
    // /// </summary>
    // private static bool IsOutgoing(List<AccountMeta> accountKeys, CompiledInstruction instruction)
    // {
    //     // Example logic to determine if the wallet is sending tokens
    //     // Replace with actual decoding logic based on SPL token transfer standards
    //     return accountKeys[instruction.Accounts[0]].PublicKey == "YourWalletAddressHere";
    // }
}