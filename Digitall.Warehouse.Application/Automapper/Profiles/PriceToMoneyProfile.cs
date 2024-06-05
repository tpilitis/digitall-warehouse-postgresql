using AutoMapper;
using Digitall.Warehouse.Application.Contracts.Shared;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Automapper.Profiles;

public class PriceToMoneyProfile : Profile
{
    public PriceToMoneyProfile()
    {
        CreateMap<Price, Money>()
            .ForCtorParam(nameof(Money.Price), opt => opt.MapFrom(src => src.Value))
            .ForCtorParam(nameof(Money.CurrencyCode), opt => opt.MapFrom(src => src.CurrencyCode))
            .ForAllMembers(opt => opt.Ignore());
    }
}
