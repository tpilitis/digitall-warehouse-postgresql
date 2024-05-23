using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Categories;
using Digitall.Warehouse.Application.Constants;
using FluentValidation;

namespace Digitall.Warehouse.Application.Products.Commands;

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

        RuleFor(command => command.CategoryIds)
            .NotEmpty()
            .MustAsync(async (ids, cancellationToken) =>
            {
                var categories = await categoryRepository!.GetAllByIdsAsync(ids, cancellationToken);

                return categories != null && categories.ToList().Count == ids.Count;
            })
            .WithErrorCode(ValidationFailureCodes.CategoriesContainNotFoundId.Name)
            .WithMessage(ValidationFailureCodes.CategoriesContainNotFoundId.Value);

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
