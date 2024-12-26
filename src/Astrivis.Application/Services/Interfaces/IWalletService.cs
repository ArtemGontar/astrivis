using Astrivis.Domain.Entities;

namespace Astrivis.Application.Services.Interfaces;

public interface IWalletService
{
    Task<IEnumerable<Wallet>> GetAllWalletsAsync(int page, int limit);
    Task<Wallet?> GetWalletInfo(Guid walletId);
}