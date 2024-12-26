using Astrivis.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrivis.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WatchlistsController : ControllerBase
{
    private readonly IWatchlistService _watchlistService;

    public WatchlistsController(IWatchlistService watchlistService)
    {
        _watchlistService = watchlistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWatchlist()
    {
        var watchlist = await _watchlistService.GetWatchlistAsync();
        return Ok(watchlist);
    }

    [HttpPost]
    public async Task<IActionResult> AddToWatchlist([FromBody] AddToWatchlistRequest request)
    {
        await _watchlistService.AddToWatchlistAsync(request.WalletId);
        return Ok(new { message = "Wallet added to watchlist." });
    }

    [HttpDelete("{walletId}")]
    public async Task<IActionResult> RemoveFromWatchlist(Guid walletId)
    {
        var result = await _watchlistService.RemoveFromWatchlistAsync(walletId);
        if (!result)
        {
            return NotFound();
        }
        return Ok(new { message = "Wallet removed from watchlist." });
    }
}

public class AddToWatchlistRequest
{
    public Guid WalletId { get; set; }
}