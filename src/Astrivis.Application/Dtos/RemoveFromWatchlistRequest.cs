namespace Astrivis.Application.Dtos;

/// <summary>Represents a request to remove a wallet from a user's watchlist.</summary>
public record RemoveFromWatchlistRequest(string WalletAddress);