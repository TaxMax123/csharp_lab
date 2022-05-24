using BankApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using BankApp.Shared.Dto;


namespace BankApp.Server.Controllers;

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
    public async Task<List<UniversalOrderGetDto>> GetOrders() => await _userOrderService.GetOrders();
    
    [HttpGet]
    [Route("/api/orders/{id:int}")]
    public async Task<UniversalOrderGetDto> GetOrderById(int id) => await _userOrderService.GetOrderById(id);
    
    // [HttpGet]
    // [Route("/api/SortedOrders")]
    // public async Task<IActionResult> SortedOrders(string param) =>
    //     View("Index", await _userOrderService.GetSortedOrders(param));
    //
    //
    // [HttpGet]
    // [Route("/api/FilteredOrders")]
    // public async Task<IActionResult> FilteredOrders(string filterBy, string? name, int? amount) =>
    //     View("Index", await _userOrderService.GetFilteredOrders(filterBy, name, amount));
    //
    // [HttpPost]
    // [Route("/api/new")]
    // public async Task<string> PostOrder(UniversalOrderPostDto universalOrder) =>
    //     await _userOrderService.PostUniversalOrder(universalOrder);
}