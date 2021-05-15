namespace Jaroszek.PoC.SignalRChat.Infrastructure.Chat.QueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Events;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Queries;
    using Jaroszek.PoC.SignalRChat.Application.Exceptions;
    using Jaroszek.PoC.SignalRChat.Domain.Entities;
    using MediatR;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class ReadMessagesHandler : IRequestHandler<ReadMessage>
    {
        private readonly IMemoryCache cache;
        private readonly ILogger<ReadMessagesHandler> logger;
        private readonly IMediator mediator;

        public ReadMessagesHandler(IMemoryCache cache, ILogger<ReadMessagesHandler> logger, IMediator mediator) =>
        (this.cache, this.logger, this.mediator) = (cache, logger, mediator);

        public async Task<Unit> Handle(ReadMessage request, CancellationToken cancellationToken)
        {
            if (cache.TryGetValue(request.MessageId, out MessageEntities message))
            {
                var notification = new SentMessage
                {
                    Message = message.Message,
                    UserName = message.UserName,
                };

                await this.mediator.Publish(notification, cancellationToken).ConfigureAwait(true);
            }
            else
            {
                throw new NotFoundMessageException(request.MessageId);
            }
            return await Task.FromResult(Unit.Value).ConfigureAwait(false);
        }
    }
}
