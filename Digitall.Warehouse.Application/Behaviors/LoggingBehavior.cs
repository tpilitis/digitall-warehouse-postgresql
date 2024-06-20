using Digitall.Warehouse.Domain.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Digitall.Warehouse.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var featureName = request!.GetType().Name;
        try
        {
            _logger.LogHandlingFeatureRequestMessage(featureName, request);

            var response = await next();

            if (request!.GetType().IsSubclassOf(typeof(IRequest<Result>)))
            {
                _logger.LogHandledVoidFeatureMessage(featureName);
            }
            else
            {
                _logger.LogHandledResponseFeatureMessage(featureName, response);
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogErrorMessage(featureName, ex);
        }

        // we shall never reach here ...
        return await next();
    }
}
