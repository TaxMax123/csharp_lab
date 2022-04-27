using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entities;
using WebApplication1.Dto;


namespace WebApplication1.Services;

public class UserOrderService : IUserOrderService
{
    private readonly UniversalOrderContext _universalOrderContext;


    public UserOrderService(UniversalOrderContext universalOrderContext)
    {
        _universalOrderContext = universalOrderContext;
    }

    public async Task<List<string>> GetModels()
    {
        await Task.Yield();
        List<string> rList = new()
        {
            "00",
            "99"
        };
        return rList;
    }

    public async Task<List<string>> GetCurrencies()
    {
        var allCurrencies = await _universalOrderContext.Currencies.ToListAsync();
        var returnValue = new List<string>();
        foreach (var allCurrency in allCurrencies)
        {
            returnValue.Add(allCurrency.Name);
        }

        return returnValue;
    }

    public async Task<string> PostUniversalOrder(UniversalOrderPostDto universalOrder)
    {
        var currency = await _universalOrderContext.Currencies.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == universalOrder.Currency);
        if (currency == null) return "Unknown currency";
        var config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<UniversalOrderPostDto, UniversalOrder>()
                    .ForMember(
                        vm => vm.Currency,
                        m => m.MapFrom(_ => currency)
                    ).ForMember(
                        vm => vm.Id,
                        m => m.Ignore()
                    );
            }
        );
        var mapper = config.CreateMapper();
        var order = mapper.Map<UniversalOrder>(universalOrder);

        var sth = await _universalOrderContext.Currencies.Include(b => b.UniversalOrders).FirstAsync();
        sth.UniversalOrders.Add(order);
        var res = await _universalOrderContext.SaveChangesAsync();
        return "Created transaction";
    }
}