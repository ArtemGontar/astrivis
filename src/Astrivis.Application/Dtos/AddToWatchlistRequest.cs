namespace Astrivis.Application.Dtos;

/// <summary>Represents a request to add a wallet to a user's watchlist.</summary>
public record AddToWatchlistRequest
{
    /// <summary>The address of the user's wallet.</summary>
    public string UserWalletAddress { get; init; }

    /// <summary>The address of the wallet to be added to the watchlist.</summary>
    public string WalletAddress { get; init; }
}
