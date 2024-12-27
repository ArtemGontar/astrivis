namespace Astrivis.Application.Dtos;

/// <summary>Represents a request to remove a wallet from a user's watchlist.</summary>
public record RemoveFromWatchlistRequest
{
    /// <summary>The address of the user's wallet.</summary>
    public string UserWalletAddress { get; init; }

    /// <summary>The address of the wallet to be added to the watchlist.</summary>
    public string WalletAddress { get; init; }
}