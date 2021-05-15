namespace Jaroszek.PoC.SignalRChat.WebUI.Jobs
{
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Commands;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Queries;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal sealed class SendDelayMessage : ISendDelayMessage
    {
        private readonly ILogger<SendDelayMessage> logger;
        private readonly IMediator mediator;

        public SendDelayMessage(ILogger<SendDelayMessage> logger, IMediator mediator) =>
            (this.logger, this.mediator) = (logger, mediator);

        public async Task Run(string userName, string message)
        {
            var command = new SendMessage
            {
                Message = message,
                UserName = userName,
            };

            this.logger.LogInformation("{Command}", command);

            _ = await this.mediator.Send(command);
        }

        public async Task Run(SendMessage command)
        {
            this.logger.LogInformation("{Command}", command);
            _ = await this.mediator.Send(command);
        }
        public async Task Run(ReadMessage command)
        {
            this.logger.LogInformation("{Command}", command);
            _ = await this.mediator.Send(command);
        }
    }
}
