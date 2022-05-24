using BankApp.Shared.Dto;

namespace BankApp.Client.Services;

public interface IUniversalOrderService
{ 
    List<UniversalOrderGetDto> UniversalOrders { get; set; }
    
    Task GetUniversalOrders();

    Task<UniversalOrderGetDto> GetOrderById(int id);
}