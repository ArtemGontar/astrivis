using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Astrivis.Application.Services.Interfaces;
using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Clients;
using Astrivis.Infrastructure.Repositories;

namespace Astrivis.Application.Services;

public class WalletService(IWalletRepository walletRepository, ISolanaClient solanaClient)
    : IWalletService
{
    public Task<IEnumerable<Wallet>> GetAllWalletsAsync(int page, int limit)
    {
        return walletRepository.GetAllAsync();
    }

    public Task<Wallet?> GetWalletInfo(string walletId)
    {
        return solanaClient.GetWalletInfoAsync(walletId);
    }

    public async Task<Wallet> AddWalletAsync(string walletId)
    {
        var walletInfo =  await solanaClient.GetWalletInfoAsync(walletId);
        if(walletInfo == null)
        {
            //TODO: Return 404 if wallet not found
            throw new Exception("Wallet not found");
        }

        return await walletRepository.AddAsync(walletInfo);
    }
}