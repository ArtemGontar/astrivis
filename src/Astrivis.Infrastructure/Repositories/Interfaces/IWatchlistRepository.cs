using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure.Repositories.Interfaces;

public interface IWatchlistRepository
{
    /// <summary>
    /// Retrieves a watchlist entry by its unique ID.
    /// </summary>
    /// <param name="watchlistId">The unique identifier of the watchlist entry.</param>
    /// <returns>The corresponding watchlist entry or null if not found.</returns>
    Task<Watchlist?> GetByIdAsync(Guid watchlistId);

    /// <summary>
    /// Retrieves all watchlist entries for a specific user by their wallet address.
    /// </summary>
    /// <param name="userWalletAddress">The wallet address of the user.</param>
    /// <returns>A collection of watchlist entries associated with the wallet.</returns>
    Task<IReadOnlyList<Watchlist>> GetByUserWalletAddressAsync(string userWalletAddress);

    /// <summary>
    /// Adds a new entry to the watchlist.
    /// </summary>
    /// <param name="watchlist">The watchlist entry to add.</param>
    /// <returns>The added watchlist entry.</returns>
    Task<Watchlist> AddAsync(Watchlist watchlist);

    /// <summary>
    /// Removes a specific entry from the watchlist.
    /// </summary>
    /// <param name="watchlistId">The unique identifier of the watchlist entry to remove.</param>
    /// <returns>True if the entry was removed successfully; otherwise, false.</returns>
    Task<bool> RemoveAsync(Guid watchlistId);
}