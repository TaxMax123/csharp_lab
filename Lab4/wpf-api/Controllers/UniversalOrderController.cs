using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

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
    public async  Task<List<string>> GetCurrencies() => await _userOrderService.GetCurrencies();


    [HttpGet]
    [Route("/api/enum/models")]
    public async Task<List<string>> GetModels() => await _userOrderService.GetModels();

    [HttpGet]
    [Route("/api/orders")]
    public async Task<List<UniversalOrderGetDto>> GetOrders() => await _userOrderService.GetOrders();

    [HttpGet]
    [Route("/api/ShowAllOrders")]
    public async Task<IActionResult> ShowAllOrders() => View("Index", await GetOrders());

    [HttpGet]
    [Route("/api/SortedOrders")]
    public async Task<IActionResult> SortedOrders(string param)
    {
        var allOrders = await GetOrders();
        var sortedOrders = allOrders.OrderBy(e => e.SenderName);
        
        if (param == "amount")
        {
            sortedOrders = allOrders.OrderBy(e => e.Amount);
        }
        return View("Index",sortedOrders);
    }

    [HttpPost]
    [Route("/api/new")]
    public async Task<string> PostOrder(UniversalOrderPostDto universalOrder) =>
        await _userOrderService.PostUniversalOrder(universalOrder);
    
}