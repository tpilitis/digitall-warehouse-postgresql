using AutoMapper;
using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public class SearchProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IQueryHandler<SearchProductsQuery, PaginatedResponseT<GetProductResponse>>
{
    private IProductRepository _productRepository = productRepository;
    private IMapper _mapper = mapper;

    public async Task<Result<PaginatedResponseT<GetProductResponse>>> Handle(
        SearchProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.SearchProductsAsync(
            request.Keyword,
            request.Skip,
            request.Take,
            cancellationToken);

        var productResponse = new List<GetProductResponse>();
        if (products.Count is not 0)
        {
            productResponse = products.Select(_mapper.Map<GetProductResponse>).ToList();
        }

        var paginatedResponse = new PaginatedResponseT<GetProductResponse>(productResponse);

        return Result.Success(paginatedResponse);
    }
}
