namespace Astrivis.Domain.Entities;

public class TransactionDetails
{
    public string Signature { get; set; }
    public DateTime Date { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Amount { get; set; }
}