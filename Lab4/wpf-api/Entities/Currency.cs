namespace WebApplication1.Entities;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual List<UniversalOrder> UniversalOrders { get; set; } 
}