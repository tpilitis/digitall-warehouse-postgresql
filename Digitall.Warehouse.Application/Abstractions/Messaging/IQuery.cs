using Digitall.Warehouse.Domain.Shared;
using MediatR;

namespace Digitall.Warehouse.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
