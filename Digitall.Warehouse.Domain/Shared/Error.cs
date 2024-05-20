namespace Digitall.Warehouse.Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public const string NullValueCode = "Error.NullValue";
    public const string DuplicatedValueCode = "Error.Duplicated";

    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new($"{NullValueCode}", "Null value was provided");

    public static Error DuplicatedValue(string valueName) => new($"{DuplicatedValueCode}", $"'{valueName}' must be unique.");

    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);
}
