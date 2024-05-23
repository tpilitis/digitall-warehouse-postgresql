using Digitall.Warehouse.Domain.Shared;
using FluentValidation;
using MediatR;

namespace Digitall.Warehouse.Application.Behaviors;

public class RequestValidatiorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<Result<TResponse>>
{
    IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidatiorBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // pre
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var validationFailures = await Task
            .WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

        var errors = validationFailures
            .SelectMany(validator => validator.Errors)
            .Where(error => error is not null);

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();

        // post
    }
}
