using Astrivis.Domain.Entities;
using Astrivis.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Astrivis.Infrastructure.Repositories;

/// <inheritdoc />
public class WalletRepository(ApplicationDbContext dbContext) : IWalletRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<Wallet?> GetByIdAsync(Guid walletId)
    {
        return await _dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);
    }

    /// <inheritdoc />
    public async Task<(IEnumerable<Wallet> wallets, int totalCount)> GetAllAsync(int page, int limit)
    {
        var walletsTask = _dbContext.Wallets
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();

        var totalCountTask = _dbContext.Wallets.CountAsync();

        await Task.WhenAll(walletsTask, totalCountTask);

        return (walletsTask.Result, totalCountTask.Result);
    }

    /// <inheritdoc />
    public async Task<Wallet> AddAsync(Wallet wallet)
    {
        var entity = await _dbContext.Wallets.AddAsync(wallet);
        await _dbContext.SaveChangesAsync();
        return entity.Entity;
    }
}