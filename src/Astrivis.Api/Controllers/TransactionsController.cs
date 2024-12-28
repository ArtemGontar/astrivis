using Astrivis.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrivis.Api.Controllers;

public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    private readonly ITransactionService _transactionService = transactionService;
    [HttpGet]
    [Route("history/{walletAddress}")]
    public async Task<IActionResult> GetTransactionHistory(
        [FromRoute] string walletAddress,
        [FromQuery] ulong limit = 10,
        [FromQuery] string beforeSignature = null)
    {
        if (string.IsNullOrWhiteSpace(walletAddress))
        {
            return BadRequest("Wallet address is required.");
        }

        try
        {
            var transactions = await _transactionService.GetRecentTransactionsAsync(walletAddress, limit, beforeSignature);
            return Ok(transactions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}