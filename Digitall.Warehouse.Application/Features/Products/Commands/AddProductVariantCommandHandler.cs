using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Commands;

public class AddProductVariantCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<AddProductVariantCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(AddProductVariantCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId, cancellationToken);

        if (product == null)
        {
            return Result.Failure(new Error(ErrorType.ResourceNotFound.Name, ErrorType.ResourceNotFound.Value));
        }

        product.AddProductVariant(request.SizeId, request.Quantity, request.SwatchId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
