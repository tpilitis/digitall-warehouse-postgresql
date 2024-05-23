namespace Digitall.Warehouse.Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new(ErrorType.NullValue.Value, "Null value was provided.");

    public static Error NotFoundValue(string valueName, string value) => new(ErrorType.ResourceNotFound.Value, $"'{valueName}' with value: '{value}' not found.");

    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);
}
