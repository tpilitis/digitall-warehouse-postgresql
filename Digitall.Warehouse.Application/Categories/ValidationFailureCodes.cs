using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Categories;

public class ValidationFailureCodes : FailureCode<ValidationFailureCodes>
{
    public static readonly ValidationFailureCodes CategoryNameAlreadyExists = new(nameof(CategoryNameAlreadyExists), "Category name must be unique.");

    public ValidationFailureCodes(string code, string message)
    : base(code, message)
    {
    }
}
