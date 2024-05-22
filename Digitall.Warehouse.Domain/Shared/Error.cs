namespace Digitall.Warehouse.Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public const string NullValueCode = "Error.NullValue";
    public const string DuplicatedValueCode = "Error.Duplicated";
    public const string RequiredValueCode = "Error.Required";
    public const string NotFoundValueCode = "Error.NotFound";

    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new($"{NullValueCode}", "Null value was provided.");

    public static Error DuplicatedValue(string valueName) => new($"{DuplicatedValueCode}", $"'{valueName}' must be unique.");
    public static Error RequiredValue(string valueName) => new($"{RequiredValueCode}", $"'{valueName}' is required.");
    public static Error NotFoundValue(string valueName, string value) => new($"{NotFoundValueCode}", $"'{valueName}' with value: '{value}' not found.");

    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);
}
