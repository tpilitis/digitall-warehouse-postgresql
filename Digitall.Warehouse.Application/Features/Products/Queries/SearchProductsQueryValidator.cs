using Digitall.Warehouse.Application.Constants;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Products.Queries
{
    public class SearchProductsQueryValidator : AbstractValidator<SearchProductsQuery>
    {
        public SearchProductsQueryValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(query => query.Keyword)
                .NotEmpty()
                .MinimumLength(EntityTypeConstants.MinTitleLength)
                .MaximumLength(EntityTypeConstants.MaxLength255);
        }
    }
}
