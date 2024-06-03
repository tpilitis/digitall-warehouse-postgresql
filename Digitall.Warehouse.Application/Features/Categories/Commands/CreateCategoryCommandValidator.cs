using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Constants;
using Digitall.Warehouse.Application.Features.Categories;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(cmd => cmd.Name)
            .NotEmpty()
            .MaximumLength(EntityTypeConstants.MaxLength255)
            .MustAsync(async (name, cancelationToken) =>
            {
                var category = await categoryRepository!.GetByNameAsync(name);
                return category == null;
            })
            .WithErrorCode(ValidationFailureCodes.CategoryNameAlreadyExists.Name)
            .WithMessage(ValidationFailureCodes.CategoryNameAlreadyExists);
    }
}
