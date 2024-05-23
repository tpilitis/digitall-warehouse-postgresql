using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Constants;
using Digitall.Warehouse.Application.Features.Categories;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Products.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(ICategoryRepository categoryRepository, IBrandRepository brandRepository)
    {
        RuleFor(command => command.Title)
            .NotEmpty();

        RuleFor(command => command.Description)
            .MaximumLength(EntityTypeConstants.MaxLength255)
            .When(commad => !string.IsNullOrEmpty(commad.Description));

        RuleFor(command => command.Price)
            .NotNull()
            .SetValidator(new PriceValidator());

        RuleFor(command => command.CategoryId)
            .NotEmpty()
            .MustAsync(async (id, cancellationToken) =>
            {
                var category = await categoryRepository!.GetByIdAsync(id, cancellationToken);

                return category != null;
            })
            .WithErrorCode(ValidationFailureCodes.CategoryNotFound.Name)
            .WithMessage(ValidationFailureCodes.CategoryNotFound.Value);

        RuleFor(command => command.BrandId)
            .NotEmpty()
            .MustAsync(async (id, cancellationToken) =>
            {
                var entity = await brandRepository!.GetByIdAsync(id, cancellationToken);

                return entity != null;
            })
            .WithErrorCode(ValidationFailureCodes.EntityDoesNotExists)
            .WithMessage("Brand does not exists.");
    }
}
