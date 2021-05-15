namespace Jaroszek.PoC.SignalRChat.Application.Chat.Events
{
    using MediatR;

    public sealed record SentMessage : INotification
    {
        public string UserName { get; init; }
        public string Message { get; init; }
    }
}
