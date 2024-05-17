using Digital.Warehouse.Utils;

namespace Digitall.Warehouse.Application.Abstractions.Messaging
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<Result> HandleAsync(TCommand command, CancellationToken token);
    }

    public interface ICommandHandler<in TCommand, TResponse> 
        where TCommand : ICommand<TResponse>
        where TResponse : class
    {
        Task<Result<TResponse>> HandleAsync(TCommand command, CancellationToken token);
    }
}
