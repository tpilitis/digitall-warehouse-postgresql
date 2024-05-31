using AutoMapper;
using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public class GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IQueryHandler<GetProductQuery, GetProductResponse>
{
    private IProductRepository _productRepository = productRepository;
    private IMapper _mapper = mapper;

    public async Task<Result<GetProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdWithBrandAsync(request.ProductId, cancellationToken);

        if (product == null)
        {
            return Result.Failure<GetProductResponse>(Error.NotFoundValue("Product", request.ProductId.ToString()));
        }

        var productResponse = _mapper.Map<GetProductResponse>(product);

        return Result.Success(productResponse);
    }
}
