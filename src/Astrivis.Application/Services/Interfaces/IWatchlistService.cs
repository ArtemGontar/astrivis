using System.Threading.Tasks;
using Astrivis.Domain.Entities;

namespace Astrivis.Application.Services.Interfaces;

public interface IWatchlistService
{
    Task<IEnumerable<Watchlist>> GetWatchlistAsync(string userWalletAddress);
    Task<Watchlist> AddToWatchlistAsync(string userWalletAddress, string walletAddress);
    Task<bool> RemoveFromWatchlistAsync(string userWalletAddress, string walletAddress);
}