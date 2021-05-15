namespace Jaroszek.PoC.SignalRChat.Domain.Exceptions
{
    using System;
    public class UserNameMustNotBeEmptyException : DomainException
    {
        public override string Code => "user_name_must_be_not_empty";
        public Guid Id { get; }

        public UserNameMustNotBeEmptyException(Guid id) : base($"User name in message {id} is empty") =>
        this.Id = id;
    }
}
