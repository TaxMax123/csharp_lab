namespace WebApplication1.Models;

public class CurrencyRatio
{
    public int Id { get; set; }
    public virtual Currency Currency { get; set; } = null!;
    public virtual Currency ReferentCurrency { get; set; } = null!;
    public double Ratio { get; set; }
}