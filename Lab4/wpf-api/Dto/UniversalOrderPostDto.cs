namespace WebApplication1.Dto;

public class UniversalOrderPostDto
{
    public string SenderName { get; set; } = null!;
    public string SenderSurname { get; set; } = null!;
    public string SenderAddress { get; set; } = null!;
    public string SenderIban { get; set; } = null!;
    public string SenderCall { get; set; } = null!;
    public string SenderModel { get; set; } = null!;
    public string ReceiverName { get; set; } = null!;
    public string ReceiverSurname { get; set; } = null!;
    public string ReceiverAddress { get; set; } = null!;
    public string ReceiverIban { get; set; } = null!;
    public string ReceiverCall { get; set; } = null!;
    public string ReceiverModel { get; set; } = null!;
    public int Currency { get; set; }
    public double Amount { get; set; }
    public bool Urgent { get; set; }
    public DateTime ExecutionDate { get; set; }
}