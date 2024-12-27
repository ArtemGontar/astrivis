using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure.Repositories.Interfaces;

/// <summary>
/// Defines the contract for interacting with the wallet data store.
/// Provides methods for retrieving, adding, and managing wallets.
/// </summary>
public interface IWalletRepository
{
    /// <summary>
    /// Retrieves a paginated list of all wallets.
    /// </summary>
    /// <param name="page">The page number for pagination.</param>
    /// <param name="limit">The number of wallets per page.</param>
    /// <returns>A tuple containing a collection of wallets and the total count of wallets.</returns>
    Task<(IEnumerable<Wallet> wallets, int totalCount)> GetAllAsync(int page, int limit);

    /// <summary>
    /// Retrieves a wallet by its unique ID.
    /// </summary>
    /// <param name="walletAddress">The unique identifier of the wallet.</param>
    /// <returns>The corresponding wallet or null if not found.</returns>
    Task<Wallet?> GetByIdAsync(Guid walletAddress);

    /// <summary>
    /// Adds a new wallet to the repository.
    /// </summary>
    /// <param name="wallet">The wallet to add.</param>
    /// <returns>The added wallet.</returns>
    Task<Wallet> AddAsync(Wallet wallet);
}

