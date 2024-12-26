using System.Threading.Tasks;

namespace Astrivis.Application.Services.Interfaces;

public interface IWatchlistService
{
    Task<object> GetWatchlistAsync();
    Task AddToWatchlistAsync(string walletId);

    Task<bool> RemoveFromWatchlistAsync(string walletId);
}