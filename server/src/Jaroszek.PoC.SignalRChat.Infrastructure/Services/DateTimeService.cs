namespace Jaroszek.PoC.SignalRChat.Infrastructure.Services
{
    using System;

    public sealed class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
