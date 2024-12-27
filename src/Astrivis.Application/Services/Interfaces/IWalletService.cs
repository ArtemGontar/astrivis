using Astrivis.Domain.Entities;

namespace Astrivis.Application.Services.Interfaces;

/// <summary>
/// Defines the contract for managing wallet-related business logic and interactions.
/// Provides methods for retrieving, adding, and fetching wallet information.
/// </summary>
public interface IWalletService
{
    /// <summary>
    /// Retrieves a paginated list of all wallets.
    /// </summary>
    /// <param name="page">The page number for pagination.</param>
    /// <param name="limit">The number of wallets per page.</param>
    /// <returns>A tuple containing a collection of wallets and the total count of wallets.</returns>
    Task<(IEnumerable<Wallet> wallets, int totalCount)> GetAllWalletsAsync(int page, int limit);

    /// <summary>
    /// Retrieves detailed information for a specific wallet by its address.
    /// </summary>
    /// <param name="walletAddress">The wallet address to fetch information for.</param>
    /// <returns>The wallet with details or null if not found.</returns>
    Task<Wallet?> GetWalletInfo(string walletAddress);

    /// <summary>
    /// Adds a new wallet by its address.
    /// </summary>
    /// <param name="walletAddress">The wallet address to add.</param>
    /// <returns>The added wallet.</returns>
    Task<Wallet> AddWalletAsync(string walletAddress);
}
