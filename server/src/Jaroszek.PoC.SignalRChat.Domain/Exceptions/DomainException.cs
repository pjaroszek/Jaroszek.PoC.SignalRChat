namespace Jaroszek.PoC.SignalRChat.Domain.Exceptions
{
    using System;
    public abstract class DomainException : Exception
    {
        public abstract string Code { get; }
        protected DomainException(string message) : base(message) { }
    }

}
