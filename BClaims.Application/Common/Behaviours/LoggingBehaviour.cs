using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace BClaims.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest>(ILogger _logger) : IRequestPreProcessor<TRequest>
    { 
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("BClaims Request: {Name} {@Request}", requestName, request);
        }
    }
}
