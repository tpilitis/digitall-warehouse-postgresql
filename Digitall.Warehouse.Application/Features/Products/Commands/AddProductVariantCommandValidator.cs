using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Features.Products.Extensions;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Products.Commands
{
    public class AddProductVariantCommandValidator : AbstractValidator<AddProductVariantCommand>
    {
        public AddProductVariantCommandValidator(
            IProductRepository productRepository,
            IProductSwatchRepository swatchRepository,
            IProductSizeRepository productSizeRepository)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.ProductId)
                .ProductMustExist(productRepository);

            RuleFor(command => command.SwatchId)
                .MustAsync(async (sId, cancellationToken) =>
                {
                    if (sId.HasValue)
                    {
                        var swatch = await swatchRepository.GetByIdAsync(sId!.Value, cancellationToken);
                        return swatch != null;
                    }

                    return true;
                })
                .WithErrorCode(ValidationFailureCodes.SwatchNotFound.Name)
                .WithMessage(ValidationFailureCodes.SwatchNotFound.Value);

            RuleFor(command => command.SizeId)
               .NotEmpty()
               .MustAsync(async (sId, cancellationToken) =>
               {
                   var swatch = await productSizeRepository.GetByIdAsync(sId, cancellationToken);
                   return swatch != null;
               })
               .WithErrorCode(ValidationFailureCodes.SizeNotFound.Name)
               .WithMessage(ValidationFailureCodes.SizeNotFound.Value);

            RuleFor(command => command.Quantity)
                .GreaterThan(0)
                .WithErrorCode(ValidationFailureCodes.QuantityGreaterThanZero.Name)
                .WithMessage(ValidationFailureCodes.QuantityGreaterThanZero.Value);
        }
    }
}
