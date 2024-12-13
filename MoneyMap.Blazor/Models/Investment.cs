namespace MoneyMap.Blazor.Models;

public class Investment
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string? InvestmentType { get; set; }
    public decimal Amount { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string? Notes { get; set; }
}