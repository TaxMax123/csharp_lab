using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreWebApplication1.Dto;
using ASP.NETCoreWebApplication1.Services;
using Newtonsoft.Json;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Route("/api")]
public class UniversalOrderController : Controller
{
    private readonly IUserOrderService _userOrderService;

    public UniversalOrderController(IUserOrderService userOrderService)
    {
        _userOrderService = userOrderService;
    }

    [HttpGet]
    [Route("/api/enum/currencies")]
    public async Task<List<string>> GetCurrencies() => await _userOrderService.GetCurrencies();


    [HttpGet]
    [Route("/api/enum/models")]
    public async Task<List<string>> GetModels() => await _userOrderService.GetModels();

    [HttpGet]
    [Route("/api/orders")]
    public async Task<string> GetOrders()
    {
       var data =  await _userOrderService.GetOrders();
       return JsonConvert.SerializeObject(data);
    }

    [HttpGet]
    [Route("/api/SortedOrders")]
    public async Task<string> SortedOrders(string param) {
      var data =  await _userOrderService.GetSortedOrders(param);
      return JsonConvert.SerializeObject(data);
    }


    [HttpGet]
    [Route("/api/FilteredOrders")]
    public async Task<object> FilteredOrders(string filterBy, string? name, int? amount) =>
        await _userOrderService.GetFilteredOrders(filterBy, name, amount);

    [HttpPost]
    [Route("/api/new")]
    public async Task<string> PostOrder(UniversalOrderPostDto universalOrder) =>
        await _userOrderService.PostUniversalOrder(universalOrder);

    [HttpDelete]
    [Route("/api/delete/{id:int}")]
    public async Task<string> DeleteOrder(int id) => await _userOrderService.DeleteOrder(id);

    [HttpPut]
    [Route("/api/update/{id:int}")]
    public async Task<string> UpdateOrder(int id, UniversalOrderGetDto order) =>
        await _userOrderService.UpdateOrder(id, order);
}