using Astrivis.Application.Dtos;
using Astrivis.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrivis.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WatchlistsController(IWatchlistService watchlistService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWatchlist()
    {
        var watchlist = await watchlistService.GetWatchlistAsync();
        return Ok(watchlist);
    }

    [HttpPost]
    public async Task<IActionResult> AddToWatchlist([FromBody] AddToWatchlistRequest request)
    {
        await watchlistService.AddToWatchlistAsync(request.WalletId);
        return Ok(new { message = "Wallet added to watchlist." });
    }

    [HttpDelete("{walletId}")]
    public async Task<IActionResult> RemoveFromWatchlist(string walletId)
    {
        var result = await watchlistService.RemoveFromWatchlistAsync(walletId);
        if (!result)
        {
            return NotFound();
        }
        return Ok(new { message = "Wallet removed from watchlist." });
    }
}