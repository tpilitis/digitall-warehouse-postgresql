using AutoMapper;
using Digitall.Warehouse.Application.Contracts.Requests.Products;
using Digitall.Warehouse.Application.Features.Products.Commands;

namespace Digitall.Warehouse.Application.Automapper.Profiles;

public class ProductVariantRequestToAddProductVariantCommandProfile : Profile
{
    public ProductVariantRequestToAddProductVariantCommandProfile()
    {
        CreateMap<ProductVariantRequest, AddProductVariantCommand>()
            .ForCtorParam(nameof(AddProductVariantCommand.ProductId), opt => opt.MapFrom(src => src.ProductId))
            .ForCtorParam(nameof(AddProductVariantCommand.SizeId), opt => opt.MapFrom(src => src.SizeId))
            .ForCtorParam(nameof(AddProductVariantCommand.SwatchId), opt => opt.MapFrom(src => src.SwatchId))
            .ForCtorParam(nameof(AddProductVariantCommand.Quantity), opt => opt.MapFrom(src => src.Quantity));
    }
}
