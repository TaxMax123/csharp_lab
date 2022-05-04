using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IUserOrderService
{
    public Task<List<string>> GetModels();
    public Task<List<string>> GetCurrencies();
    public Task<List<UniversalOrderGetDto>> GetOrders();
    public Task<string> PostUniversalOrder(UniversalOrderPostDto universalOrder);
}