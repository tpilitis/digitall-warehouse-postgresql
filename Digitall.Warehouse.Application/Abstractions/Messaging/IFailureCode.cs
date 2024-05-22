namespace Digitall.Warehouse.Application.Abstractions.Messaging
{
    public interface IFailureCode
    {
        string Name { get; init; }
        string Value { get; init; }
    }
}
