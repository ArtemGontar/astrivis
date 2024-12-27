using Astrivis.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrivis.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class WalletsController(IWalletService walletService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWallets([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var (wallets, totalCount) = await walletService.GetAllWalletsAsync(page, limit);

        return Ok(new { wallets, totalCount });
    }

    [HttpGet("{walletAddress}")]
    public async Task<IActionResult> GetWalletDetails(string walletAddress)
    {
        var wallet = await walletService.GetWalletInfo(walletAddress);
        if (wallet == null)
        {
            return NotFound();
        }
        return Ok(wallet);
    }

    [HttpPost("{walletAddress}")]
    public async Task<IActionResult> AddWallet(string walletAddress)
    {
        var result = await walletService.AddWalletAsync(walletAddress);
        return Ok(new { message = $"{result} wallets added from Solana." });
    }
}