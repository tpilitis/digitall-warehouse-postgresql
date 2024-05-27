using Digitall.Warehouse.Application.Constants;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Products.Queries
{
    public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsQueryValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(query => query.Title)
                .NotEmpty()
                .MinimumLength(EntityTypeConstants.MinTitleLength)
                .MaximumLength(EntityTypeConstants.MaxLength255);
        }
    }
}
