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
        var wallets = await walletService.GetAllWalletsAsync(page, limit);
        return Ok(wallets);
    }

    [HttpGet("{walletId}")]
    public async Task<IActionResult> GetWalletDetails(string walletId)
    {
        var wallet = await walletService.GetWalletInfo(walletId);
        if (wallet == null)
        {
            return NotFound();
        }
        return Ok(wallet);
    }

    [HttpPost("{walletId}")]
    public async Task<IActionResult> AddWallet(string walletId)
    {
        var result = await walletService.AddWalletAsync(walletId);
        return Ok(new { message = $"{result} wallets added from Solana." });
    }
}