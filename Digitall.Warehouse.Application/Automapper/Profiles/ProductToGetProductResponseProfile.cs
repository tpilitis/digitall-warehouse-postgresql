using AutoMapper;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Automapper.Profiles
{
    public class ProductToGetProductResponseProfile : Profile
    {
        public ProductToGetProductResponseProfile()
        {
            CreateMap<Product, GetProductResponse>()
                .ForCtorParam(nameof(GetProductResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(GetProductResponse.Description), opt => opt.MapFrom(src => src.Description))
                .ForCtorParam(nameof(GetProductResponse.Price), opt => opt.MapFrom(src => src.Price))
                .ForCtorParam(nameof(GetProductResponse.Brand), opt => opt.MapFrom(src => src.Brand != null ? src.Brand!.Name : null));
        }
    }
}
