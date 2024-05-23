using Microsoft.Extensions.Logging;

namespace Digitall.Warehouse.Application.Behaviors
{
    internal static partial class LoggerMessageDefinitionsGen
    {
        [LoggerMessage(EventId = 0, Level = LogLevel.Information, Message = "Handling feature '@{FeatureName}' with request '@{Request}'.")]
        public static partial void LogHandlingFeatureRequestMessage(this ILogger logger, string featureName, object request);

        [LoggerMessage(EventId = 0, Level = LogLevel.Information, Message = "Feature '@{FeatureName}' handled.")]
        public static partial void LogHandledVoidFeatureMessage(this ILogger logger, string featureName);

        [LoggerMessage(EventId = 0, Level = LogLevel.Information, Message = "Feature '@{FeatureName}' handled with response: '@{Response}'.")]
        public static partial void LogHandledResponseFeatureMessage(this ILogger logger, string featureName, object? response);

        [LoggerMessage(EventId = 0, Level = LogLevel.Error, Message = "Feature '{@FeatureName}' failed.")]
        public static partial void LogErrorMessage(this ILogger logger, string featureName, Exception exception);
    }
}
