using Astrivis.Domain.Entities;

namespace Astrivis.Infrastructure;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Watchlist> Watchlists { get; set; }
}