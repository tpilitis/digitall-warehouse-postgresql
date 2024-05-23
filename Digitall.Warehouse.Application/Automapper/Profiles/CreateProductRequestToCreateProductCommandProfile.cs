using AutoMapper;
using Digitall.Warehouse.Api.Contracts.Requests.Products;
using Digitall.Warehouse.Application.Features.Products.Commands;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Automapper.Profiles;

public class CreateProductRequestToCreateProductCommandProfile : Profile
{
    public CreateProductRequestToCreateProductCommandProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<Money, Price>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Price));
    }
}
