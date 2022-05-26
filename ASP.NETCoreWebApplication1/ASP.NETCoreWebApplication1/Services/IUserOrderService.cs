using ASP.NETCoreWebApplication1.Dto;

namespace ASP.NETCoreWebApplication1.Services;

public interface IUserOrderService
{
    public Task<List<string>> GetModels();
    public Task<List<string>> GetCurrencies();
    public Task<List<UniversalOrderGetDto>> GetOrders();
    public Task<string> DeleteOrder(int id);
    public Task<string> UpdateOrder(int id, UniversalOrderGetDto order);
    public Task<string> PostUniversalOrder(UniversalOrderPostDto universalOrder);
    public Task<List<UniversalOrderGetDto>> GetSortedOrders(string param);
    public Task<List<UniversalOrderGetDto>> GetFilteredOrders(string filterBy, string? name, int? amount);
}