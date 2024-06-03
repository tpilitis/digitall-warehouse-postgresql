using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Features.Categories;

public class ValidationFailureCodes : FailureCode<ValidationFailureCodes>
{
    public static readonly ValidationFailureCodes CategoryNameAlreadyExists = new(nameof(CategoryNameAlreadyExists), "Category name must be unique.");
    public static readonly ValidationFailureCodes CategoryNotFound = new(nameof(CategoryNotFound), "Category cannot be found.");
    public static readonly ValidationFailureCodes EntityDoesNotExists = new(nameof(EntityDoesNotExists), "Entity does not exists");
    public static readonly ValidationFailureCodes IdentifierCannotBeEmpty = new(nameof(IdentifierCannotBeEmpty), "Identifier cannot be empty");

    public ValidationFailureCodes(string code, string message)
    : base(code, message)
    {
    }
}
