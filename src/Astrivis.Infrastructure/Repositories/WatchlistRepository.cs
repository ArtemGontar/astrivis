using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Repositories.Interfaces;

namespace Astrivis.Infrastructure.Repositories;

public class WatchlistRepository : IWatchlistRepository
{
    public Task<Watchlist?> GetByIdAsync(Guid watchlistId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Watchlist>> GetByUserWalletIdAsync(string userWalletId)
    {
        throw new NotImplementedException();
    }

    public Task<Watchlist> AddAsync(Watchlist watchlist)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Watchlist watchlist)
    {
        throw new NotImplementedException();
    }
}