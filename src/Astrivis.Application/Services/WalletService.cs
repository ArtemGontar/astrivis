using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Repositories;

namespace Astrivis.Application.Services;

public class WalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public Task<Wallet?> GetWalletInfo(Guid walletId)
    {
        return _walletRepository.GetByIdAsync(walletId);
    }
}