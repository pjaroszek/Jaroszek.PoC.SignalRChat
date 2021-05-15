namespace Jaroszek.PoC.SignalRChat.Domain.Entities
{
    using System;
    using Jaroszek.PoC.SignalRChat.Domain.Exceptions;

    public sealed class MessageEntities
    {
        public MessageEntities()
        {
        }
        public MessageEntities(Guid messageId, string userName, string message, DateTime addDate)
        {
            if (messageId == Guid.Empty)
            {
                throw new InvalidMessageIdException(messageId);
            }

            if (string.IsNullOrEmpty(userName))
            {
                throw new UserNameMustNotBeEmptyException(messageId);
            }

            MessageId = messageId;
            UserName = userName;
            Message = message;
            AddDate = addDate;
        }

        public Guid MessageId { get; }
        public string UserName { get; }
        public string Message { get; }
        public DateTime AddDate { get; }
        public bool IsActive { get; } = true;
    }
}
