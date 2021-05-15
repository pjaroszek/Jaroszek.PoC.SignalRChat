namespace Jaroszek.PoC.SignalRChat.Infrastructure.Chat.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Commands;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Events;
    using Jaroszek.PoC.SignalRChat.Application.Exceptions;
    using Jaroszek.PoC.SignalRChat.Domain.Entities;
    using Jaroszek.PoC.SignalRChat.Infrastructure.Services;
    using MediatR;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class SendMessageHandler : IRequestHandler<SendMessage>
    {
        private readonly IMemoryCache cache;
        private readonly IDateTime dateTime;
        private readonly ILogger<SendMessageHandler> logger;
        private readonly IMediator mediator;

        public SendMessageHandler(IMemoryCache cache, IDateTime dateTime, ILogger<SendMessageHandler> logger, IMediator mediator) =>
               (this.cache, this.dateTime, this.logger, this.mediator) = (cache, dateTime, logger, mediator);

        public async Task<Unit> Handle(SendMessage request, CancellationToken cancellationToken)
        {
            var message = new MessageEntities(Guid.NewGuid(), request.UserName, request.Message, this.dateTime.Now);

            this.cache.TryGetValue(message.MessageId, out MessageEntities messageEntities);

            if (messageEntities is null)
            {
                this.cache.Set(message.MessageId, message);

                var notification = new SentMessage
                {
                    Message = request.Message,
                    UserName = request.UserName,
                };

                await this.mediator.Publish(notification, cancellationToken).ConfigureAwait(true);
            }
            else
            {
                throw new MessageAlredyExistsException(message.MessageId);
            }

            return await Task.FromResult(Unit.Value).ConfigureAwait(false);
        }
    }
}
