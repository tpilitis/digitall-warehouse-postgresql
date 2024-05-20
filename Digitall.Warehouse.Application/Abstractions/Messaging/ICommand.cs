using Digitall.Warehouse.Domain.Shared;
using MediatR;

namespace Digitall.Warehouse.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
