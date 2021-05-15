namespace Jaroszek.PoC.SignalRChat.Application.Chat.Queries
{
    using System;
    using MediatR;
    public sealed record ReadMessage : IRequest
    {
        public Guid MessageId { get; init; }
    }

}
