using Astrivis.Application.Services.Interfaces;
using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Repositories.Interfaces;

namespace Astrivis.Application.Services;

/// <inheritdoc />
public class WatchlistService(IWatchlistRepository watchlistRepository) : IWatchlistService
{
    private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;

    /// <inheritdoc />
    public async Task<IEnumerable<Watchlist>> GetWatchlistAsync(string userWalletAddress)
    {
        return await _watchlistRepository.GetByUserWalletAddressAsync(userWalletAddress);
    }

    /// <inheritdoc />
    public async Task<Watchlist> AddToWatchlistAsync(string userWalletAddress, string walletAddress)
    {
        var watchlist = new Watchlist
        {
            WalletAddress = walletAddress,
            UserWalletAddress = userWalletAddress
        };
        return await _watchlistRepository.AddAsync(watchlist);
    }

    /// <inheritdoc />
    public async Task<bool> RemoveFromWatchlistAsync(string userWalletAddress, string walletAddress)
    {
        var watchlist = await _watchlistRepository.GetByUserWalletAddressAsync(userWalletAddress);
        var watchlistEntry = watchlist.FirstOrDefault(w => w.WalletAddress == walletAddress);

        if (watchlistEntry == null)
        {
            return false;
        }

        return await _watchlistRepository.RemoveAsync(watchlistEntry.Id);
    }
}