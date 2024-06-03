using AutoMapper;
using Digitall.Warehouse.Api.Contracts.Requests.Products;
using Digitall.Warehouse.Application.Features.Products.Commands;

namespace Digitall.Warehouse.Application.Automapper.Profiles;

public class CreateProductRequestToCreateProductCommandProfile : Profile
{
    public CreateProductRequestToCreateProductCommandProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>()
            .ForCtorParam(nameof(CreateProductCommand.Title), opt => opt.MapFrom(src => src.Title))
            .ForCtorParam(nameof(CreateProductCommand.Description), opt => opt.MapFrom(src => src.Description))
            .ForCtorParam(nameof(CreateProductCommand.Price), opt => opt.MapFrom(src => src.Price))
            .ForCtorParam(nameof(CreateProductCommand.BrandId), opt => opt.MapFrom(src => src.BrandId))
            .ForCtorParam(nameof(CreateProductCommand.CategoryId), opt => opt.MapFrom(src => src.CategoryId))
            .ForAllMembers(opt => opt.Ignore());
    }
}
