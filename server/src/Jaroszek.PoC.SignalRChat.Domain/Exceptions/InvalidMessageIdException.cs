namespace Jaroszek.PoC.SignalRChat.Domain.Exceptions
{
    using System;

    public sealed class InvalidMessageIdException : DomainException
    {
        public override string Code => "invalid_message_id";
        public Guid Id { get; }

        public InvalidMessageIdException(Guid id) : base($"Invalid Message Id: {id}")
        {
            Id = id;
        }
    }
}
