using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Astrivis.Infrastructure.Repositories;

public class WatchlistRepository(ApplicationDbContext dbContext) : IWatchlistRepository
{
    private readonly ApplicationDbContext _context = dbContext;

    /// <inheritdoc />
    public async Task<Watchlist?> GetByIdAsync(Guid watchlistId)
    {
        return await _context.Watchlists.FindAsync(watchlistId);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Watchlist>> GetByUserWalletAddressAsync(string userWalletAddress)
    {
        return await _context.Watchlists
            .Where(w => w.UserWalletAddress == userWalletAddress)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Watchlist> AddAsync(Watchlist watchlist)
    {
        watchlist.Id = Guid.NewGuid();
        watchlist.CreatedAt = DateTime.UtcNow;
        _context.Watchlists.Add(watchlist);
        await _context.SaveChangesAsync();
        return watchlist;
    }

    /// <inheritdoc />
    public async Task<bool> RemoveAsync(Guid watchlistId)
    {
        var watchlist = await GetByIdAsync(watchlistId);

        if (watchlist == null)
        {
            return false;
        }

        _context.Watchlists.Remove(watchlist);
        await _context.SaveChangesAsync();
        return true;
    }
}