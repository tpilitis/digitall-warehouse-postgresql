using Ardalis.SmartEnum;

namespace Digitall.Warehouse.Domain.Shared;

public class ErrorType(string name, string value) : SmartEnum<ErrorType, string>(name, value)
{
    private const string ValuePrefix = "Error.";

    public static ErrorType NullValue = new(nameof(NullValue), $"{ValuePrefix}{nameof(NullValue)}");
    public static ErrorType ResourceNotFound = new(nameof(ResourceNotFound), $"{ValuePrefix}{nameof(ResourceNotFound)}");
}
