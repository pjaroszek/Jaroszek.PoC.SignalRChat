namespace Jaroszek.PoC.SignalRChat.Domain.Entities
{
    using System;

    public sealed class MessageEntities
    {
        public Guid MessageId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime AddDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
