using Astrivis.Domain.Entities;

namespace Astrivis.Application.Services.Interfaces;

/// <summary>
/// Defines the contract for managing watchlist-related business logic and interactions.
/// Provides methods for retrieving, adding, and removing wallets from a user's watchlist.
/// </summary>
public interface IWatchlistService
{
    /// <summary>
    /// Retrieves the watchlist of wallets for a specific user.
    /// </summary>
    /// <param name="userWalletAddress">The wallet address of the user.</param>
    /// <returns>A collection of watchlist entries associated with the user's wallet address.</returns>
    Task<IEnumerable<Watchlist>> GetWatchlistAsync(string userWalletAddress);

    /// <summary>
    /// Adds a specific wallet to the user's watchlist.
    /// </summary>
    /// <param name="userWalletAddress">The wallet address of the user.</param>
    /// <param name="walletAddress">The wallet address to add to the watchlist.</param>
    /// <returns>The added watchlist entry.</returns>
    Task<Watchlist> AddToWatchlistAsync(string userWalletAddress, string walletAddress);

    /// <summary>
    /// Removes a specific wallet from the user's watchlist.
    /// </summary>
    /// <param name="userWalletAddress">The wallet address of the user.</param>
    /// <param name="walletAddress">The wallet address to remove from the watchlist.</param>
    /// <returns>True if the wallet was removed successfully; otherwise, false.</returns>
    Task<bool> RemoveFromWatchlistAsync(string userWalletAddress, string walletAddress);
}
