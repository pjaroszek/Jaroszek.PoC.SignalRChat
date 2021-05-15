namespace Jaroszek.PoC.SignalRChat.Domain.Entities
{
    using System;
    public class ReadMessageEntities
    {
        public string UserName { get; init; }
        public string Message { get; init; }
        public DateTime AddDate { get; init; }
    }
}
