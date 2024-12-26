namespace Astrivis.Domain.Entities;

public class Wallet
{
    public Guid Id { get; set; }
    public string WalletAddress { get; set; }
    public decimal Balance { get; set; }
    public string? OwnerName { get; set; }
}