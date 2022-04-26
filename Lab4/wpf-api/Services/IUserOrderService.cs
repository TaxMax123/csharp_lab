using WebApplication1.Dto;

namespace WebApplication1.Services;

public interface IUserOrderService
{
    public Task<List<string>> GetCurrencies();
    public Task<string> PostUniversalOrder(UniversalOrderPostDto universalOrder);
}