using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Categories;

public class ValidationFailureCodes : FailureCode<ValidationFailureCodes>
{
    public static readonly ValidationFailureCodes CategoryNameAlreadyExists = new(nameof(CategoryNameAlreadyExists), "Category name must be unique.");
    public static readonly ValidationFailureCodes CategoriesContainNotFoundId = new(nameof(CategoriesContainNotFoundId), "Categories contain identifier which cannot be found.");
    public static readonly ValidationFailureCodes EntityDoesNotExists = new(nameof(EntityDoesNotExists), "Entity does not exists");

    public ValidationFailureCodes(string code, string message)
    : base(code, message)
    {
    }
}
