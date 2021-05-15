namespace Jaroszek.PoC.SignalRChat.WebUI.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Events;
    using Jaroszek.PoC.SignalRChat.WebUI.Hubs;
    using MediatR;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;

    internal sealed class SentMessageHandler : INotificationHandler<SentMessage>
    {
        private readonly IHubContext<ChatHub> hubContext;
        private readonly ILogger<SentMessageHandler> logger;

        public SentMessageHandler(IHubContext<ChatHub> hubContext, ILogger<SentMessageHandler> logger) =>
            (this.hubContext, this.logger) = (hubContext, logger);

        public async Task Handle(SentMessage notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("{Event}", notification);
            await this.hubContext.Clients.All.SendAsync("ReceiveMessage", notification);
        }
    }
}