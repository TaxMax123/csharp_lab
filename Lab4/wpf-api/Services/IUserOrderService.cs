using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IUserOrderService
{
    public Task<List<string>> GetModels();
    public Task<List<string>> GetCurrencies();
    public Task<List<UniversalOrderGetDto>> GetOrders();
    public Task<string> PostUniversalOrder(UniversalOrderPostDto universalOrder);
    public Task<List<UniversalOrderGetDto>> GetSortedOrders(string param);
    public Task<List<UniversalOrderGetDto>> GetFilteredOrders(string filterBy, string? name, int? amount);
}