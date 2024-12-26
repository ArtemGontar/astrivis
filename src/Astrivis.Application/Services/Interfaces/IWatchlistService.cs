using System.Threading.Tasks;
using Astrivis.Domain.Entities;

namespace Astrivis.Application.Services.Interfaces;

public interface IWatchlistService
{
    Task<IEnumerable<Watchlist>> GetWatchlistAsync(string userWalletId);
    Task<Watchlist> AddToWatchlistAsync(string userWalletId, string walletId);
    Task<bool> RemoveFromWatchlistAsync(string userWalletId, string walletId);
}