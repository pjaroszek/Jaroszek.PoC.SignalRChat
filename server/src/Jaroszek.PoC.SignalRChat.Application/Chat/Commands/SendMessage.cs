namespace Jaroszek.PoC.SignalRChat.Application.Chat.Commands
{
    using MediatR;

    public sealed record SendMessage : IRequest
    {
        public string UserName { get; init; }
        public string Message { get; init; }
    }

}
