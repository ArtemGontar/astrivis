namespace Astrivis.Domain.Entities;

/// <summary>
/// Represents a watchlist entry for tracking specific wallets on the Solana blockchain.
/// </summary>
public class Watchlist
{
    /// <summary>
    /// the unique identifier of the watchlist entry.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The wallet address of the user who owns this watchlist entry.
    /// </summary>
    public string UserWalletAddress { get; set; }

    /// <summary>
    /// The wallet address being tracked in this watchlist entry.
    /// </summary>
    public string WalletAddress { get; set; }

    /// <summary>
    /// The date and time when the watchlist entry was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
