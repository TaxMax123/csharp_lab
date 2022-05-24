using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BankApp.Shared.Dto;
namespace BankApp.Client.Services;

public class UniversalOrderService : IUniversalOrderService
{
    private readonly HttpClient _http;

    public UniversalOrderService(HttpClient http)
    {
        _http = http;
    }

    public List<UniversalOrderGetDto> UniversalOrders { get; set; } = new List<UniversalOrderGetDto>();

    public async Task GetUniversalOrders()
    {
        var results = await _http.GetFromJsonAsync<List<UniversalOrderGetDto>>("api/orders");
        if (results != null)
        {
            UniversalOrders = results;
        }
    }

    public async Task<UniversalOrderGetDto> GetOrderById(int id)
    {
        var result = await _http.GetFromJsonAsync<UniversalOrderGetDto>($"api/orders/{id}");
        if (result != null)
        {
            return result;
        }

        throw new Exception("Order not found!");
    }
}