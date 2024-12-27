using Astrivis.Application.Dtos;
using Astrivis.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrivis.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WatchlistsController(IWatchlistService watchlistService) : ControllerBase
{
    [HttpGet("{userWalletAddress}")]
    public async Task<IActionResult> GetWatchlist(string userWalletAddress)
    {
        var watchlist = await watchlistService.GetWatchlistAsync(userWalletAddress);
        return Ok(watchlist);
    }

    [HttpPost("{userWalletAddress}")]
    public async Task<IActionResult> AddToWatchlist([FromRoute] string userWalletAddress, [FromBody] AddToWatchlistRequest request)
    {
        await watchlistService.AddToWatchlistAsync(userWalletAddress, request.WalletAddress);
        return Ok(new { message = "Wallet added to watchlist." });
    }

    [HttpDelete("{userWalletAddress}")]
    public async Task<IActionResult> RemoveFromWatchlist([FromRoute] string userWalletAddress, [FromBody] RemoveFromWatchlistRequest request)
    {
        var result = await watchlistService.RemoveFromWatchlistAsync(userWalletAddress ,request.WalletAddress);
        if (!result)
        {
            return NotFound();
        }
        return Ok(new { message = "Wallet removed from watchlist." });
    }
}