using Digitall.Warehouse.Application.Features.Categories;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(query => query.ProductId)
            .Must((productId) =>
            {
                return !productId.Equals(Guid.Empty);
            })
            .WithErrorCode(ValidationFailureCodes.IdentifierCannotBeEmpty.Name)
            .WithMessage(ValidationFailureCodes.IdentifierCannotBeEmpty.Value);
    }
}
