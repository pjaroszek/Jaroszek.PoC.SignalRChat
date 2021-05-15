namespace Jaroszek.PoC.SignalRChat.Application.Exceptions
{
    using System;
    public abstract class AppException : Exception
    {
        public abstract string Code { get; }
        protected AppException(string message) : base(message) { }
    }
}
