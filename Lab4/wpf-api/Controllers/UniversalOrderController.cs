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
    [Route("/api/enum/models")]
    public List<string> GetModels()
    {
        var rList = new List<string>
        {
            "00",
            "99"
        };
        return rList;
    }

    [HttpPost]
    [Route("/api/new")]
    public string PostOrder(UniversalOrderPostDto universalOrder)
    {
        return _userOrderService.PostUniversalOrder(universalOrder).Result;
    }
}