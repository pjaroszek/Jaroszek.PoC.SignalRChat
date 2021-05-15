namespace Jaroszek.PoC.SignalRChat.Application.Exceptions
{
    using System;

    public class NotFoundMessageException : AppException
    {
        public override string Code => "not_found_message";
        public Guid Id { get; }

        public NotFoundMessageException(Guid id) : base($"Not Found message by id: {id}") =>
       this.Id = id;
    }
}
