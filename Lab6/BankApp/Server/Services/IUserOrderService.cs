using System.Collections;
using BankApp.Shared.Dto;

namespace BankApp.Server.Services;

public interface IUserOrderService
{
    Task<List<string>> GetModels();
    Task<List<string>> GetCurrencies();
    Task<List<UniversalOrderGetDto?>> GetOrders();
    Task<UniversalOrderGetDto> GetOrderById(int Id);
    Task<string> PostUniversalOrder(UniversalOrderPostDto universalOrder);
    Task<List<UniversalOrderGetDto>> GetSortedOrders(string param);
    Task<List<UniversalOrderGetDto?>> GetFilteredOrders(string filterBy, string? name, int? amount);
}