using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Features.Categories;
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
                .NotEmpty()
                .MustAsync(async (pId, cancellationToken) =>
                {
                    var product = await productRepository.GetByIdAsync(pId, cancellationToken);
                    return product != null;
                })
                .WithErrorCode(ValidationFailureCodes.ProductNotFound.Name)
                .WithMessage(ValidationFailureCodes.ProductNotFound.Value);

            RuleFor(command => command.SwatchId)
                .NotEmpty()
                .MustAsync(async (sId, cancellationToken) =>
                {
                    var swatch = await swatchRepository.GetByIdAsync(sId!.Value, cancellationToken);
                    return swatch != null;
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
        }
    }
}
