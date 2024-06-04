using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Features;

public class ValidationFailureCodes : FailureCode<ValidationFailureCodes>
{
    public static readonly ValidationFailureCodes CategoryNameAlreadyExists = new(nameof(CategoryNameAlreadyExists), "Category name must be unique.");
    public static readonly ValidationFailureCodes CategoryNotFound = new(nameof(CategoryNotFound), "Category cannot be found.");
    public static readonly ValidationFailureCodes EntityDoesNotExists = new(nameof(EntityDoesNotExists), "Entity does not exists");
    public static readonly ValidationFailureCodes IdentifierCannotBeEmpty = new(nameof(IdentifierCannotBeEmpty), "Identifier cannot be empty");
    public static readonly ValidationFailureCodes ProductNotFound = new(nameof(ProductNotFound), "Product cannot be found.");
    public static readonly ValidationFailureCodes SwatchNotFound = new(nameof(SwatchNotFound), "Swatch cannot be found.");
    public static readonly ValidationFailureCodes SizeNotFound = new(nameof(SizeNotFound), "Size cannot be found.");
    public static readonly ValidationFailureCodes QuantityGreaterThanZero = new(nameof(QuantityGreaterThanZero), "Quantity shall be greather than zero.");
    public static readonly ValidationFailureCodes RequiredId = new(nameof(RequiredId), "Identifier is required.");

    public ValidationFailureCodes(string code, string message)
    : base(code, message)
    {
    }
}
