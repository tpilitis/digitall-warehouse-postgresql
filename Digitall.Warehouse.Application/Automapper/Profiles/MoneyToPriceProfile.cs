using AutoMapper;
using Digitall.Warehouse.Application.Contracts.Shared;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Automapper.Profiles
{
    public class MoneyToPriceProfile : Profile
    {
        public MoneyToPriceProfile()
        {
            CreateMap<Money, Price>()
               .ForCtorParam(nameof(Price.Value), opt => opt.MapFrom(src => src.Price))
               .ForCtorParam(nameof(Price.CurrencyCode), opt => opt.MapFrom(src => src.CurrencyCode))
               .ForAllMembers(opt => opt.Ignore());
        }
    }
}
