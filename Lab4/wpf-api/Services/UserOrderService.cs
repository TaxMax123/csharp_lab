using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;
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

    public async Task<List<UniversalOrderGetDto>> GetOrders()
    {
        var allOrders = await _universalOrderContext.UniversalOrders
            .ToListAsync();
        var allOrderDtos = new List<UniversalOrderGetDto>();
        var mapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<UniversalOrder, UniversalOrderGetDto>()
                    .ForMember(
                        vm => vm.Currency,
                        m => m.MapFrom(
                            o => _universalOrderContext.Currencies.Find(o.CurrencyId).Name
                        ));
            }
        ).CreateMapper();
        foreach (var order in allOrders)
        {
            allOrderDtos.Add(mapper.Map<UniversalOrderGetDto>(order));
        }

        return allOrderDtos;
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

        var sth = await _universalOrderContext.Currencies
            .Include(b => b.UniversalOrders)
            .FirstOrDefaultAsync(b => b.Id == currency.Id);

        sth?.UniversalOrders.Add(order);
        var res = await _universalOrderContext.SaveChangesAsync();
        return "Created transaction";
    }
}