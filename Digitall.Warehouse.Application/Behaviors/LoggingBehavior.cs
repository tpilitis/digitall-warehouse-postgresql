using Digitall.Warehouse.Domain.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Digitall.Warehouse.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
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
        var commandName = request!.GetType().Name;

        try
        {
            _logger.LogInformation(
                "Handling command @{CommandName} with request {Command}", commandName, request);

            var response = await next();

            if (request.GetType().IsSubclassOf(typeof(IRequest<Result>)))
            {
                _logger.LogInformation("Command @{CommandName} handled.", commandName);
            }
            else
            {
                _logger.LogInformation("Command @{CommandName} handled with response: @{Response}.", commandName, response);
            }
            
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Command {@CommandName} failed. With {@Exception}", commandName, ex);
        }

        // I do not expect we to reach here...
        return await next();
    }
}
