using AutoMapper;
using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public class GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper) : IQueryHandler<GetProductsQuery, List<GetProductResponse>>
{
    private IProductRepository _productRepository = productRepository;
    private IMapper _mapper = mapper;

    public async Task<Result<List<GetProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsByTitleAsync(
            request.Title,
            request.Skip,
            request.Take,
            cancellationToken);

        var productResponse = new List<GetProductResponse>();
        if (products.Count is not 0)
        {
            productResponse = products.Select(_mapper.Map<GetProductResponse>).ToList();
        }

        return Result.Success(productResponse);
    }
}
