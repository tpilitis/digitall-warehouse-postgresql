using Ardalis.SmartEnum;

namespace Digitall.Warehouse.Application.Abstractions.Messaging;

public class FailureCode<TEnum>(string name, string value) :
    SmartEnum<TEnum, string>(name, value), IFailureCode
    where TEnum : SmartEnum<TEnum, string>
{
    public new string Name { get; init; } = name;
    public new string Value { get; init; } = value;
}
