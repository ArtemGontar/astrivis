using Astrivis.Application.Services.Interfaces;
using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Clients;
using Astrivis.Infrastructure.Repositories;
using Astrivis.Infrastructure.Repositories.Interfaces;

namespace Astrivis.Application.Services;

/// <inheritdoc />
public class WalletService(IWalletRepository walletRepository, ISolanaClient solanaClient)
    : IWalletService
{
    /// <inheritdoc />
    public Task<(IEnumerable<Wallet> wallets, int totalCount)> GetAllWalletsAsync(int page, int limit)
    {
        return walletRepository.GetAllAsync(page, limit);
    }

    /// <inheritdoc />
    public Task<Wallet?> GetWalletInfo(string walletAddress)
    {
        return solanaClient.GetWalletInfoAsync(walletAddress);
    }

    /// <inheritdoc />
    public async Task<Wallet> AddWalletAsync(string walletAddress)
    {
        var walletInfo =  await solanaClient.GetWalletInfoAsync(walletAddress);
        if(walletInfo == null)
        {
            //TODO: Return 404 if wallet not found
            throw new Exception("Wallet not found");
        }

        return await walletRepository.AddAsync(walletInfo);
    }
}