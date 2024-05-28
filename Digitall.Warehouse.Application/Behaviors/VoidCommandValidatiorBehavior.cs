using Digitall.Warehouse.Application.Abstractions;
using Digitall.Warehouse.Domain.Shared;
using FluentValidation;
using MediatR;

namespace Digitall.Warehouse.Application.Behaviors
{
    public class VoidCommandValidatiorBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<Result>
    {
        IEnumerable<IValidator<TRequest>> _validators;
        IValidationService _validationService;

        public VoidCommandValidatiorBehavior(
            IEnumerable<IValidator<TRequest>> validators,
            IValidationService validationService)
        {
            _validators = validators;
            _validationService = validationService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // pre
            var errors = await _validationService.ValidateRequestAsync(request, _validators, cancellationToken);
            
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
