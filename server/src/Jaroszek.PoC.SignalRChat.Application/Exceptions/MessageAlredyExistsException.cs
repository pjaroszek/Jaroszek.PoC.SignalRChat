namespace Jaroszek.PoC.SignalRChat.Application.Exceptions
{
    using System;
    public class MessageAlredyExistsException : AppException
    {
        public override string Code => "message_alredy_exists";
        public Guid Id { get; }

        public MessageAlredyExistsException(Guid id) : base($"Resource with id: {id} already exists.") =>
        this.Id = id;
    }
}