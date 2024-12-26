namespace Astrivis.Domain.Entities;

public class Watchlist
{
    public int Id { get; set; }
    public string UserWalletId { get; set; }
    public string WalletId { get; set; }
    public DateTime CreatedAt { get; set; }
}
