using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQueryValidator : AbstractValidator<GetCategoryByNameQuery>
    {
        public GetCategoryByNameQueryValidator()
        {
            RuleFor(category => category.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
