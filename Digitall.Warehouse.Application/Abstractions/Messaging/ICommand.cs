namespace Digitall.Warehouse.Application.Abstractions.Messaging
{
    public interface ICommand : ICommandBase
    {
    }

    public interface ICommand<TResponse> : ICommandBase
    {
    }

    public interface ICommandBase
    {
    }
}
