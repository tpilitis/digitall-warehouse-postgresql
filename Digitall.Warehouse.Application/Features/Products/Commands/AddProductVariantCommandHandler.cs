using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Commands;

public class AddProductVariantCommandHandler(IProductRepository productRepository) :
    ICommandHandler<AddProductVariantCommand>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result> Handle(AddProductVariantCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdWithProductVariantBySizeIdAsync(request.ProductId, request.SizeId, cancellationToken);
        
        product!.AddProductVariant(request.SizeId, request.Quantity, request.SwatchId);
        _productRepository.Update(product);

        return Result.Success();
    }
}
