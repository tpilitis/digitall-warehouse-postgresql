namespace Digitall.Warehouse.Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

    public static Error DuplicatedValue(string valueName) => new("Error.Duplicated", $"'{valueName}' must be unique.");

    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);
}
