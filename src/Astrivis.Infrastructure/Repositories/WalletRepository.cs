using Astrivis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Astrivis.Infrastructure.Repositories;

public class WalletRepository(ApplicationDbContext dbContext) : IWalletRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Wallet?> GetByIdAsync(Guid walletId)
    {
        return await _dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);
    }

    public async Task<IEnumerable<Wallet?>> GetAllAsync()
    {
        return await _dbContext.Wallets.ToListAsync();
    }
}