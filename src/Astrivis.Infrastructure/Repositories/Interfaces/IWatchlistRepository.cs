using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure.Repositories.Interfaces;

public interface IWatchlistRepository
{
    Task<Watchlist?> GetByIdAsync(Guid watchlistId);

    Task<IEnumerable<Watchlist>> GetByUserWalletIdAsync(string userWalletId);
    Task<Watchlist> AddAsync(Watchlist watchlist);

    Task<bool> RemoveAsync(Watchlist watchlist);
}