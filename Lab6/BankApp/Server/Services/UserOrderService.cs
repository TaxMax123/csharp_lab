
using System.Collections;
using AutoMapper;
using BankApp.Client.Services;
using BankApp.Shared;
using BankApp.Server.Data;
using BankApp.Shared.Dto;
using Microsoft.EntityFrameworkCore;


namespace BankApp.Server.Services;

public class UserOrderService : IUserOrderService
{
    private readonly UniversalOrderContext _universalOrderContext;
    private IMapper _mapper;

    public UserOrderService(UniversalOrderContext universalOrderContext)
    {
        _universalOrderContext = universalOrderContext;
        _mapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<UniversalOrder, UniversalOrderGetDto>()
                    .ForMember(
                        vm => vm.Currency,
                        m => m.MapFrom(
                            o => _universalOrderContext.Currencies.Find(o.CurrencyId)!.Name
                        ));
            }
        ).CreateMapper();
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
        return allCurrencies.Select(allCurrency => allCurrency.Name).ToList();
    }

    public async Task<List<UniversalOrderGetDto>> GetOrders()
    {
        var allOrders = await _universalOrderContext.UniversalOrders
            .ToListAsync();

        return allOrders.Select(order => _mapper.Map<UniversalOrderGetDto>(order)).ToList();
    }

    public async Task<UniversalOrderGetDto> GetOrderById(int Id)
    {
        var allOrders = await GetOrders();
        return allOrders?.Where(o => o.Id == Id).FirstOrDefault();

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

    public async Task<List<UniversalOrderGetDto>> GetSortedOrders(string param)
    {
        var allOrders = await GetOrders();
        var sortedOrders = param == "amount" ? allOrders.OrderBy(e => e.Amount) : allOrders.OrderBy(e => e.SenderName);
        return sortedOrders.ToList();
    }

    public async Task<List<UniversalOrderGetDto>> GetFilteredOrders(string filterBy, string? name, int? amount)
    {
        var allOrders = await GetOrders();
        switch (filterBy)
        {
            case "SenderName":
            {
                var filteredOrders = allOrders.Where(e => e.SenderName == name);
                return filteredOrders.ToList();
            }
            case "ReceiverName":
            {
                var filteredOrders = allOrders.Where(e => e.ReceiverName == name);
                return filteredOrders.ToList();
            }
            case ">amount":
            {
                var filteredOrders = allOrders.Where(e => e.Amount >= amount);
                return filteredOrders.ToList();
            }
            case "<amount":
            {
                var filteredOrders = allOrders.Where(e => e.Amount <= amount);
                return filteredOrders.ToList();
            }
            default:
            {
                return allOrders;
            }
        }
    }
}