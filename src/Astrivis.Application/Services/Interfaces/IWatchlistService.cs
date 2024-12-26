namespace Astrivis.Application.Services.Interfaces;

public interface IWatchlistService
{
    Task<object> GetWatchlistAsync();
    Task AddToWatchlistAsync(Guid walletId);

    Task<bool> RemoveFromWatchlistAsync(Guid walletId);
}