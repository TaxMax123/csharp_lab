using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
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


    [HttpPost]
    [Route("/api/new")]
    public async Task<string> PostOrder(UniversalOrderPostDto universalOrder) =>
        await _userOrderService.PostUniversalOrder(universalOrder);
}