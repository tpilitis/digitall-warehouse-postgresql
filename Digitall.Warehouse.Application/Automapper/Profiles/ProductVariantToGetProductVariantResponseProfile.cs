using AutoMapper;
using Digitall.Warehouse.Application.Contracts.Dtos;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Automapper.Profiles;

public class ProductVariantToGetProductVariantResponseProfile : Profile
{
    public ProductVariantToGetProductVariantResponseProfile()
    {
        CreateMap<ProductVariant, GetProductVariantResponse>()
            .ForCtorParam(nameof(GetProductVariantResponse.ProductId), opt => opt.MapFrom(src => src.ProductId))
            .ForCtorParam(nameof(GetProductVariantResponse.Quantity), opt => opt.MapFrom(src => src.Quantity))
            .ForCtorParam(nameof(GetProductVariantResponse.Swatch), opt => opt.MapFrom(src => src.Swatch))
            .ForCtorParam(nameof(GetProductVariantResponse.Size), opt => opt.MapFrom(src => src.Size));

        CreateMap<ProductSize, SizeDto>()
            .ForCtorParam(nameof(SizeDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(SizeDto.Name), opt => opt.MapFrom(src => src.Name))
            .ForCtorParam(nameof(SizeDto.Description), opt => opt.MapFrom(src => src.Description));

        CreateMap<ProductSwatch, SwatchDto>()
            .ForCtorParam(nameof(SwatchDto.Id), opt => opt.MapFrom(src => src.Id));
    }
}
