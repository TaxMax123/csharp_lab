namespace BankApp.Shared;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<UniversalOrder> UniversalOrders { get; set; } = null!;
}