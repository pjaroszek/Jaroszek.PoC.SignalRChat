namespace Jaroszek.PoC.SignalRChat.Application.Behaviours
{
    using Microsoft.Extensions.Logging;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> logger;
        public LoggingBehaviour(ILogger<TRequest> logger) =>
        this.logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this.logger.LogInformation("Executing {method}", typeof(TRequest));
            var response = await next().ConfigureAwait(false);
            this.logger.LogInformation("Executed {method}", typeof(TRequest));
            return response;
        }
    }
}
