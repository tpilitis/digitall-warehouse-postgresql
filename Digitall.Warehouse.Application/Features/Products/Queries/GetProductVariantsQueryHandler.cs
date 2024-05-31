using AutoMapper;
using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Queries
{
    public class GetProductVariantsQueryHandler(IProductVariantRepository productVariantRepository, IMapper mapper)
                : IQueryHandler<GetProductVariantsQuery, List<GetProductVariantResponse>>
    {
        private readonly IProductVariantRepository _productVariantRepository = productVariantRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<GetProductVariantResponse>>> Handle(
            GetProductVariantsQuery request,
            CancellationToken cancellationToken)
        {
            var productVariants = await _productVariantRepository.GetVariantsAsync(request.ProductId, cancellationToken);

            List<GetProductVariantResponse> productVariantsResponse = productVariants == null ? []
                : productVariants!.Select(_mapper.Map<GetProductVariantResponse>).ToList();

            return Result.Success(productVariantsResponse);
        }
    }
}
