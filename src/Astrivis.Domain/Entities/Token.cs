namespace Astrivis.Domain.Entities;

/// <summary>
/// Represents a token associated with a wallet, including its address and balance.
/// </summary>
public record Token
{
    /// <summary>
    /// The unique identifier of the token.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The unique address of the token.
    /// </summary>
    public string TokenAddress { get; init; }

    /// <summary>
    /// The balance of the token.
    /// </summary>
    public decimal Balance { get; init; }
}
