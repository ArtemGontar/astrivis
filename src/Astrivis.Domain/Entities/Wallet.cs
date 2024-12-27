namespace Astrivis.Domain.Entities;

/// <summary>
/// Represents a wallet on the Solana blockchain, including its address, balance, owner information, and associated tokens.
/// </summary>
public class Wallet
{
    /// <summary>
    /// The unique identifier of the wallet.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The blockchain wallet address.
    /// </summary>
    public string WalletAddress { get; set; }

    /// <summary>
    /// The current balance of the wallet.
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// The name of the wallet owner, if available.
    /// </summary>
    public string? OwnerName { get; set; }

    /// <summary>
    /// The collection of tokens associated with the wallet.
    /// </summary>
    public ICollection<Token> Tokens { get; set; } = new List<Token>();
}
