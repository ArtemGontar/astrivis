using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure.Repositories;

public interface IWalletRepository
{
    Task<Wallet?> GetByIdAsync(Guid walletId);
    Task<IEnumerable<Wallet>> GetAllAsync();
    Task<Wallet> AddAsync(Wallet wallet);
}
