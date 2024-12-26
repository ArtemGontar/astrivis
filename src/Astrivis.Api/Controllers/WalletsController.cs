using Astrivis.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrivis.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class WalletsController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletsController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWallets([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var wallets = await _walletService.GetAllWalletsAsync(page, limit);
        return Ok(wallets);
    }

    [HttpGet("{walletId}")]
    public async Task<IActionResult> GetWalletDetails(Guid walletId)
    {
        var wallet = await _walletService.GetWalletInfo(walletId);
        if (wallet == null)
        {
            return NotFound();
        }
        return Ok(wallet);
    }
}