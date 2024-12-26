using Astrivis.Application.Services.Interfaces;
using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Repositories.Interfaces;

namespace Astrivis.Application.Services;

public class WatchlistService(IWatchlistRepository watchlistRepository) : IWatchlistService
{
    private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;

    public async Task<IEnumerable<Watchlist>> GetWatchlistAsync(string userWalletId)
    {
        return await _watchlistRepository.GetByUserWalletIdAsync(userWalletId);
    }

    public async Task<Watchlist> AddToWatchlistAsync(string userWalletId, string walletId)
    {
        var watchlist = new Watchlist
        {
            WalletId = walletId,
            UserWalletId = userWalletId,
            CreatedAt = DateTime.UtcNow
        };
        return await _watchlistRepository.AddAsync(watchlist);
    }

    public async Task<bool> RemoveFromWatchlistAsync(string userWalletId, string walletId)
    {
        throw new NotImplementedException();
    }
}