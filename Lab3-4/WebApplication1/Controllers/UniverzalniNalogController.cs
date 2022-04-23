using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api")]
public class UniverzalniNalogController : Controller
{
    [HttpGet]
    [Route("/api/enum/currencies")]
    public List<string> GetCurrencies()
    {
        return Enum.GetNames(typeof(Currency)).ToList();
    }

    [HttpGet]
    [Route("/api/enum/models")]
    public List<string> GetModels()
    {
        var RList = new List<string>();
        RList.Add("00");
        RList.Add("99");
        return RList;
    }

    [HttpPost]
    [Route("/api/new")]
    public void PostNalog(UniverzalniNalog univerzalniNalog)
    {
        univerzalniNalog.DatumIzvrsenja = new DateTime();
        Console.WriteLine(univerzalniNalog.Platitelj.Ime);
        Console.WriteLine(univerzalniNalog.Primatelj.Ime);
        Console.WriteLine(univerzalniNalog.ValutaPlacanja);
        Console.WriteLine(univerzalniNalog.Iznos);
        Console.WriteLine(univerzalniNalog.Hitno);
    }
}